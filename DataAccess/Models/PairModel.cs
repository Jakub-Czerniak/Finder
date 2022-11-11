namespace DataAccess.Models
{
    public class PairModel
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public string User1Decision { get; set; } = string.Empty; 
        public string User2Decision { get; set; } = string.Empty;
        public System.DateTime MatchDate { get; set; }
    }
}
