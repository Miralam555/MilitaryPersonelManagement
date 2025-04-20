using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;

            var isAsync = typeof(Task).IsAssignableFrom(returnType);

            if (isAsync)
            {
                InterceptAsync(invocation, returnType);
            }
            else
            {
                InterceptSync(invocation);
            }
        }

        private void InterceptSync(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
                OnAfter(invocation);
            }
        }

        private void InterceptAsync(IInvocation invocation, Type returnType)
        {
            OnBefore(invocation);
            invocation.Proceed();

            if (returnType == typeof(Task))
            {
                invocation.ReturnValue = InterceptAsyncInternal((Task)invocation.ReturnValue, invocation);
            }
            else 
            {
                var resultType = returnType.GetGenericArguments()[0];
                var method = typeof(MethodInterception).GetMethod(nameof(InterceptAsyncWithResult),
                    BindingFlags.Instance | BindingFlags.NonPublic);
                var genericMethod = method.MakeGenericMethod(resultType);

                invocation.ReturnValue = genericMethod.Invoke(this, new object[] { invocation.ReturnValue, invocation });
            }
        }

        private async Task InterceptAsyncInternal(Task task, IInvocation invocation)
        {
            var isSuccess = true;
            try
            {
                await task;
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
                OnAfter(invocation);
            }
        }

        private async Task<T> InterceptAsyncWithResult<T>(Task<T> task, IInvocation invocation)
        {
            var isSuccess = true;
            try
            {
                var result = await task;
                return result;
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
                OnAfter(invocation);
            }
        }
    }
}
