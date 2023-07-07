namespace EmailApi.Interfaces
{
    public class Interfaces
    {
        public interface IEmailService
        {
            string get_username();
            string get_password();
            string get_mailaddress();
            string get_mailserv();
        }

    }
}
