using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Labs.MusicLibrary.Business.Common
{
    public class OperationResult
    {
        private bool _hasSucceeded;
        protected bool _hasSucceededBeenChecked;

        public bool HasSucceeded
        {
            get 
            {
                _hasSucceededBeenChecked = true;
                return _hasSucceeded; 
            }
            set { _hasSucceeded = value; }
        }


        public Exception Exception { get; set; }

        public OperationResult(bool hasSucceeded, Exception ex = null)
        {
            HasSucceeded = hasSucceeded;
            Exception = ex;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        private T _result;

        public T Result
        {
            get 
            {
                if (!_hasSucceededBeenChecked) throw new OperationCanceledException("Please check the HasSucceeded property :)");
                return _result; 
            }
            set { _result = value; }
        }


        public OperationResult(T result) : base(true, null)
        {
            Result = result;
        }

        public OperationResult(bool hasSucceeded, Exception ex = null) : base(hasSucceeded, ex)
        {

        }
    }
}
