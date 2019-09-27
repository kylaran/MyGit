using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Services.Client;
using System.Net;
using System.IO;

namespace TestLes.Models
{
    public class Login
    {
        public const string authServicesUri = "http://shedko.beesender.com/ServiceModel/AuthService.svc/Login";
        public static CookieContainer AuthCookie = new CookieContainer();
        public static bool TryLogin(string userName = "Supervisor", string userPassword = "Supervisor")
        {
            var authRequest = HttpWebRequest.Create(authServicesUri) as HttpWebRequest;
            authRequest.ContentType = "application/json";
            authRequest.Method = "POST";
            authRequest.CookieContainer = AuthCookie;
            using (var requesrStream = authRequest.GetRequestStream())
            {
                using (var writer = new StreamWriter(requesrStream))
                {
                    writer.Write(@"{
                                    ""UserName"":""" + userName + @""",
                                    ""UserPassword"":""" + userPassword + @"""
                                   }");
                }
            }
            using (var response = (HttpWebResponse)authRequest.GetResponse())
            {
                if (AuthCookie.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
