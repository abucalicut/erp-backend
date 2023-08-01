namespace ERPBE.Controllers
{
    public class UserCred
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Authentication
    {
        public string UserName { get; set; }
        public string token { get; set; }
        public DateTime validTo { get; set; }
    }
}