using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{

    public class ResultError
    {
        public ResultError(string message)
        {
            this.Message = message;
        }

        public ResultError(Exception exception)
        {
            this.Exception = exception;
        }

        private string _message;
        public string Message
        {
            get
            {
                if (this.HasException)
                    return this.Exception.Message + " : " + this.Exception.GetBaseException().Message;
                return _message;
            }
            set
            {
                this._message = value;
                this.Exception = null;
            }
        }

        public bool HasException
        {
            get
            {
                return this.Exception != null;
            }
        }

        public Exception Exception { get; private set; }
    }
}
