using GitHub.Users.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{
    public class ParallelMessageCollector
    {

        List<ResultItem> _parallelElements = new List<ResultItem>();

        public List<ResultItem> ParallelElements { get { return _parallelElements; } }

        public void Add(ResultItem resultItem)
        {
            if (resultItem.Error == null || string.IsNullOrEmpty(resultItem.Error.Message))
                resultItem.Error = new ResultError("");
            this.Add(resultItem, false);
        }

        public void Add(ResultItem resultItem, bool ignoreNotFound)
        {
            this.Add(resultItem, ignoreNotFound, null);
        }

        public void Add(ResultItem resultItem, string notFoundMessage)
        {
            this.Add(resultItem, false, notFoundMessage);
        }

        private void Add(ResultItem resultItem, bool ignoreNotFound, string notFoundMessage)
        {
            if (resultItem != null && resultItem.ErrorStatus == ErrorStatusType.NotFound && !string.IsNullOrWhiteSpace(notFoundMessage))
                resultItem.Error.Message = notFoundMessage;

            if (!ignoreNotFound || resultItem == null || (ignoreNotFound && resultItem != null && resultItem.ErrorStatus != ErrorStatusType.NotFound))
                _parallelElements.Add(resultItem);
        }

        public bool HasErrors
        {
            get
            {
                return this.Errors.Count() != 0;
            }
        }

        public List<ResultError> Errors
        {
            get
            {
                List<ResultError> resultErrors = _parallelElements.Where(p => p == null).Select(p => new ResultError("Null reference")).ToList();
                resultErrors.AddRange(_parallelElements.Where(p => p != null && p.ErrorStatus != ErrorStatusType.NoError).Select(p => p.Error).ToList());
                return resultErrors;
            }
        }

        public List<ErrorStatusType> ErrorStatuses
        {
            get
            {
                List<ErrorStatusType> resultErrorStatuses = _parallelElements.Where(p => p == null).Select(p => ErrorStatusType.NullReferenceInput).ToList();
                resultErrorStatuses.AddRange(_parallelElements.Where(p => p != null && p.ErrorStatus != ErrorStatusType.NoError).Select(p => p.ErrorStatus).ToList());
                return resultErrorStatuses;
            }
        }

        public string ErrorMessage
        {
            get
            {
                if (!this.HasErrors)
                    return string.Empty;
                return this.Errors.Select(p => p.Message).Aggregate((x, y) => $"{x}, {y}");
            }
        }

    }
}
