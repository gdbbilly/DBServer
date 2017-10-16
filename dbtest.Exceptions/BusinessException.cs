using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbtest.Exceptions
{
    /// <summary>
    /// Exception de negocio
    /// </summary>
    public class BusinessException : Exception
    {
        private string _exceptionmessage;
        private string _stackTrace;aaaa

        public string ExceptionMessage
        {
            get { return _exceptionmessage; }
            set { _exceptionmessage = value; }
        }

        public string StackTrace
        {
            get { return _stackTrace; }
            set { _stackTrace = value; }
        }

        public BusinessException(string message)
        {
            ExceptionMessage = message;
        }

        public BusinessException(Exception ex)
        {
            StackTrace = ex.StackTrace;
            ExceptionMessage = ex.Message;
        }
    }
}
