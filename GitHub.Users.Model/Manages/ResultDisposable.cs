using GitHub.Users.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{
    public class ResultDisposable<T> : ResultItem, IDisposable where T : IDisposable
    {
        public T Item { get; set; }

        public ResultDisposable(T item)
        {
            this.Item = item;
        }

        public ResultDisposable(ErrorStatusType errorStatus)
            : base(errorStatus)
        {
        }

        public ResultDisposable(ErrorStatusType errorStatus, Exception exception)
            : base(errorStatus, exception)
        {
        }

        public void Dispose()
        {
            if (this.Item != null)
                this.Item.Dispose();
        }
    }
}
