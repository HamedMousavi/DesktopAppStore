using System;




namespace WebUi.ViewModels
{
    public class AlertInfo
    {
        public enum AlertTypes
        {
            Stop,
            OK,
            Info,
            Warning,
            Error
        }


        public AlertTypes Type { get; set; }
        public string Message { get; set; }


        public AlertInfo(AlertTypes type, string message)
        {
            this.Type = type;
            this.Message = message;
        }
    }
}