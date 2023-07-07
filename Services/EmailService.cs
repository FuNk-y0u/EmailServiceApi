using Microsoft.Extensions.Configuration;
using static EmailApi.Interfaces.Interfaces;

namespace EmailApi.Services
{
    public class EmailService : IEmailService
    {
        public string _EmailUsername;
        public string _EmailPassword;
        public string _MailAddress;
        public string _MailServ;
        public EmailService(IConfiguration config)
        {
            _EmailUsername = config["EmailUsername"];
            _EmailPassword = config["EmailPassword"];
            _MailAddress = config["MailAddress"];
            _MailServ = config["MailServ"];
        }

        public string get_username()
        {
            return _EmailUsername;
        }
        public string get_password()
        {
            return _EmailPassword;
        }

        public string get_mailaddress()
        {
            return _MailAddress;

        }
        public string get_mailserv()
        {
            return _MailServ;
        }
    }
}
