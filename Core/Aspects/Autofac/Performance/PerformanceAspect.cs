using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        private readonly IConfiguration _configuration; 
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                SendMailPerformanceWarning(invocation);
                
            }
            _stopwatch.Reset();
        }
        private void SendMailPerformanceWarning(IInvocation invocation)
        {
            string fromMail = _configuration.GetSection("SendEmailOptions")["FromMail"];
            string fromPassword = _configuration.GetSection("SendEmailOptions")["FromPassword"];

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Performance Warning";
            message.To.Add(new MailAddress("androidapps634@gmail.com"));
            message.Body = $"<html><body> {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds} </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }
    }
}
