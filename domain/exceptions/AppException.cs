using System;

namespace basketball_teams.domain.exceptions
{
    public class AppException : Exception
    {
        private string _message = null;

        public override string Message { get => _message; }
        
        public AppException()
        {
            _message = "app error";
        }
        
        public AppException(string message)
        {
            _message = message;
        }
    }
}