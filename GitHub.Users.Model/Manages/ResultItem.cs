using GitHub.Users.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{

    public class ResultItem
    {

        public ResultItem()
            : this(ErrorStatusType.NoError)
        {

        }

        public ResultItem(ResultItem resultItem)
        {
            this.Error = resultItem.Error;
            this.ErrorStatus = resultItem.ErrorStatus;
        }

        public ResultItem(ErrorStatusType errorStatus)
        {
            this.ErrorStatus = errorStatus;
        }

        public ResultItem(ErrorStatusType errorStatus, string message)
        {
            this.ErrorStatus = errorStatus;
            this.Error = new ResultError(message);
        }

        public ResultItem(ErrorStatusType errorStatus, Exception exception)
        {
            this.ErrorStatus = errorStatus;
            this.Error = new ResultError(exception);
        }

        public ResultItem(Exception exception)
            : this(ErrorStatusType.Error, exception)
        {
        }

        public ErrorStatusType ErrorStatus { get; set; }
        public ResultError Error { get; set; }


        private TAttribute GetAttribute<TAttribute>(Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

    }

}
