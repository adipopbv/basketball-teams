namespace basketball_teams.domain.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException() : base("entity not found") { }
        
        public NotFoundException(string message) : base(message) { }
    }
}