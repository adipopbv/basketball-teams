using System;
using System.Reflection.Metadata.Ecma335;
using basketball_teams.client;

namespace basketball_teams
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Client client = new ConsoleClient();
            
            client.Run();
        }
    }
}