namespace Finder.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public byte[] Photo { get; set; }
        public DateTime LastActive { get; set; }
        public bool InterestedM { get; set; }
        public bool InterestedF { get; set; }
        public string AboutMe { get; set; }
        public List<InterestModel> Interests { get; set; }
        public int MinAgePreference {get; set;}
        public int MaxAgePreference { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
    }
}