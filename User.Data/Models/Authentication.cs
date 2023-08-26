namespace User.Data.Models
{
    public class Authentication
    {
        public string UserName { get; set; }
        public string token { get; set; }
        public DateTime validTo { get; set; }
    }
}
