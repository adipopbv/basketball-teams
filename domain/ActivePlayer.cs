using System.Diagnostics;

namespace basketball_teams.domain
{
    public class ActivePlayer : Entity
    {
        public Player Player { get; set; }
        public Game Game { get; set; }
        public int ScoredPoints { get; set; }
        public GamePlayerStatus Status { get; set; }

        public ActivePlayer(Id id, Player player, Game game, int scoredPoints, GamePlayerStatus status) : base(id)
        {
            Player = player;
            Game = game;
            ScoredPoints = scoredPoints;
            Status = status;
        }

        public static GamePlayerStatus StringToStatus(string s)
        {
            switch(s)
            {
                case "Reserve": return GamePlayerStatus.Reserve;
                case "Participant": return GamePlayerStatus.Participant;
                default: return GamePlayerStatus.None;
            }
        }

        public static string StatusToString(GamePlayerStatus s)
        {
            switch(s)
            {
                case GamePlayerStatus.Reserve: return "Reserve";
                case GamePlayerStatus.Participant: return "Participant";
                default: return "None";
            }
        }
    }

    public enum GamePlayerStatus
    {
        Reserve,
        Participant,
        None
    }
}