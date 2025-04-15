using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T Data,string message):base(Data,true,message)
        {
            
        }
        public SuccessDataResult(T Data):base(Data,true)
        {
            
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
