namespace basketball_teams.domain.Exceptions
{
    public class DuplicateException: AppException
    {
        public DuplicateException() : base("duplicate entity") { }
        
        public DuplicateException(string message) : base(message) { }
    }
}