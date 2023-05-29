namespace UdemyProject.Models
{
    public class AuthModel
    {
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public User? user { get; set; }
    }
}
