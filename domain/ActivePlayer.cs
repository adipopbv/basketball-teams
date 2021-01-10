namespace basketball_teams.domain
{
    public class ActivePlayer
    {
        public Id PlayerId { get; set; }
        public Id GameId { get; set; }
        public int ScoredPoints { get; set; }
        public GamePlayerStatus Status { get; set; }

        public ActivePlayer(Id playerId, Id gameId, int scoredPoints, GamePlayerStatus status)
        {
            PlayerId = playerId;
            GameId = gameId;
            ScoredPoints = scoredPoints;
            Status = status;
        }
    }

    public enum GamePlayerStatus
    {
        Reserve,
        Participant
    }
}