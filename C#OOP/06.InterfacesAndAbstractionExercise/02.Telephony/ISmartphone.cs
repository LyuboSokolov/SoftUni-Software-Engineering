using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
   public interface ISmartphone
    {
        void CallOtherPhones(string phoneNumber);

        void BrowseWebSite(string webSite);
    }
}
