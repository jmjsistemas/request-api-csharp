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
using static testeccsharp.TesteSimple;
namespace testeccsharp
{
    class Program
    {

        
        static string BASE_URL = "http://irishomologacao.unimeduberlandia.coop.br:8080/iris/";
        static string CONTENT_TYPE = "application/x-www-form-urlencoded";
        static string getSessionID()
        {
            var client = new RestClient(BASE_URL + "login");
            var request = new RestRequest(Method.POST);


            client.AddDefaultHeader("Content-Type", CONTENT_TYPE);
            request.AddParameter("username", "appbeneficiario");
            request.AddParameter("password", "a4997e1c241729bb32174f6a4d01a790");
            var response = client.Execute(request);
            Console.WriteLine(response.Cookies[0].Name + "=" + response.Cookies[0].Value);
            return response.Cookies[0].Name + "=" + response.Cookies[0].Value;
        }

        static void getListInternacao (string sessionid) {

            var client = new RestClient(BASE_URL + "api/historico-beneficiario-api/internacoes?page=0&size=1&numeroCarteira=00142104270740092");
            var request = new RestRequest(Method.GET);
            client.AddDefaultHeader("Content-Type","application/json:charset=UTF-8");
            client.AddDefaultHeader("Cookie", sessionid);


            var response =  client.Execute(request);
            Console.WriteLine(response.Content);
            
           
        }

        static void Main(string[] args)
        {

            Console.WriteLine("----------------------------- \n Teste Utilizando RestSharp \n ---------------------------- - ");
            var sessionid = getSessionID();    
            getListInternacao(sessionid);

            Console.WriteLine("----------------------------- \n Teste Simples \n ---------------------------- - ");

            var id = TesteSimple.doLogin();
            TesteSimple.doGET(id);









        }
    }

}
