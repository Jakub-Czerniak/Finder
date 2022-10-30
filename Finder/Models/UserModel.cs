
namespace Finder.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public Image Photo { get; set; }
        public DateTime LastActive { get; set; }
        public bool InterestedM { get; set; }
        public bool InterestedF { get; set; }
        public string AboutMe { get; set; }
    }
}
