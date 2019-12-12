using System;
using System.Collections.Generic;
using System.Text;

namespace RoeiJeRot.Logic.Services
{
    public interface IMailService
    {
        void SendConfirmation();
    }
    public class MailService : IMailService
    {

    }
}
