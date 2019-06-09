using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.ViewModel
{
    public class ResultMessage
    {
        public string Message { get; set; }
        public bool Error { get; set; } 

        public ResultMessage(string messsage)
        {
            Error = true;
            Message = messsage;
        }

        public ResultMessage(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
