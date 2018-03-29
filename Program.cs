using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Timers;
using RestSharp;
using RestSharp.Authenticators;
using static testeccsharp.LoginSimple;
using static testeccsharp.LoginRestSharp;
namespace testeccsharp
{
    class Program
    {        

        static void Main(string[] args)
        {

            Console.WriteLine("----------------------------- \n Teste Utilizando RestSharp \n ---------------------------- - ");
            var sessionid = LoginRestSharp.getSessionID();
            LoginRestSharp.getListInternacao(sessionid);
            Console.WriteLine("\n\n\n ");
            Console.WriteLine("----------------------------- \n Teste Simples \n ---------------------------- - ");
            var id = LoginSimple.doLogin();
            LoginSimple.doGET(id);









        }
    }

}
