namespace DataAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public byte[] Photo { get; set; } 
        public DateTime LastActive { get; set; }
        public string InterestedM { get; set; }
        public string InterestedF { get; set; }
        public string AboutMe { get; set; } = string.Empty;
        public List<InterestModel> Interests { get; set; } = new List<InterestModel>();
        public int MinAgePreference { get; set; }
        public int MaxAgePreference { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
    }
}
