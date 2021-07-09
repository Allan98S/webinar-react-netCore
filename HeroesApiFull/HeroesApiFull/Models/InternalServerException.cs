using System;
namespace TSV.Backend.Models
{
    public class InternalServerException : Exception
    {
        public string clientMessage { get; set; }
        public InternalServerException(string message, string clientMessage) : base(message)
        {
            this.clientMessage = clientMessage;
        }
    }
}
