using basketball_teams.services;

namespace basketball_teams.client
{
    public abstract class Client
    {
        protected Service Service;

        protected Client(Service service)
        {
            this.Service = service;
        }

        public abstract void Run();
    }
}