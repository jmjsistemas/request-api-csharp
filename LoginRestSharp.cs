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
namespace testeccsharp
{
    class LoginRestSharp
    {


        static string BASE_URL = "http://irishomologacao.unimeduberlandia.coop.br:8080/iris/";
        static string CONTENT_TYPE = "application/x-www-form-urlencoded";
        public  static string getSessionID(string usuario, string senha)
        {
            Console.WriteLine("Efetuando Login!");
            var client = new RestClient(BASE_URL + "login");
            var request = new RestRequest(Method.POST);


            client.AddDefaultHeader("Content-Type", CONTENT_TYPE);
            request.AddParameter("username", usuario);
            request.AddParameter("password", senha);
            var response = client.Execute(request);
            Console.WriteLine("ID Retornado " + response.Cookies[0].Name + "=" + response.Cookies[0].Value);
            return response.Cookies[0].Name + "=" + response.Cookies[0].Value;
        }

      public  static void getListInternacao(string sessionid)
        {

            Console.WriteLine("Efetuando GET!");
            var client = new RestClient(BASE_URL + "api/historico-beneficiario-api/internacoes?page=0&size=1&numeroCarteira=00142104270740092");
            var request = new RestRequest(Method.GET);
            client.AddDefaultHeader("Content-Type", "application/json:charset=UTF-8");
            client.AddDefaultHeader("Cookie", sessionid);


            var response = client.Execute(request);
            Console.WriteLine("Resultado: " + response.Content);


        }

    }

}
