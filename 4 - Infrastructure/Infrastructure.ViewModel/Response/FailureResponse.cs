using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ViewModel.Response
{
    public class FailureResponse : FailureResponse<string>
    {

    }

    public class FailureResponse<T>
    {
        public int Code { set; get; }
        public List<T> Error { set; get; }
    }

    public class BodyOfExcetion
    {
        public int Code { set; get; }
        public string Message { set; get; }
    }
}
