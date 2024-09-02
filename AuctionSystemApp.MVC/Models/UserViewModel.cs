namespace AuctionSystemApp.MVC.Models
{
    public class UserViewModel
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public IFormFile UserPhoto { get; set; } = null!;

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Fname", Fname);
            dict.Add("Lname", Lname);
            dict.Add("Email", Email);
            dict.Add("Phone", Phone);
            return dict;
        }
    }
}
