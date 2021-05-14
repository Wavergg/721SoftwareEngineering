using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class ErrorMessage
    {
        public bool IsSuccess { get; set; }
        public List<string> Message { get; set; } = new List<string>();

        public string UrlRedirect { get; set; }

        public ErrorMessage()
        {

        }

        public ErrorMessage(bool isSuccess, List<string> message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }
    }
}
