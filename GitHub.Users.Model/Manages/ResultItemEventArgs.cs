using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{
    public class ResultItemEventArgs : EventArgs
    {
        public ResultItemEventArgs(ResultItem resultItem)
        {
            this.ResultItem = resultItem;
        }

        public ResultItem ResultItem { get; set; }
    }
}
