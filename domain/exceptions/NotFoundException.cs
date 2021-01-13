namespace basketball_teams.domain.exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException() : base("entity not found") { }
        
        public NotFoundException(string message) : base(message) { }
    }
}