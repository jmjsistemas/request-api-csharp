using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Timers;
namespace testeccsharp
{
    class LoginSimple
    {
        static string id = "";
        public static string doLogin()
        {
            Console.WriteLine("Efetuando Login!");
            string URI = "http://irishomologacao.unimeduberlandia.coop.br:8080/iris/login";
            string myParameters = "username=auditor&password=da428db3b6fc127df7f3051059c7f430";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
                WebHeaderCollection myWebHeaderCollection = wc.ResponseHeaders;
                // for (int i = 0; i < myWebHeaderCollection.Count; i++)
                //    Console.WriteLine(i+" \t" + myWebHeaderCollection.GetKey(i) + " = " + myWebHeaderCollection.Get(i));
                string[] id = myWebHeaderCollection.Get(4).Split(";");
                Console.WriteLine("ID Retornado " + id[0]);

                return id[0];
            }
        }

        public static void doGET(string id)
        {
            Console.WriteLine("Efetuando GET!");
            const string WEBSERVICE_URL = "http://irishomologacao.unimeduberlandia.coop.br:8080/iris/api/historico-beneficiario-api/internacoes?page=0&size=1&numeroCarteira=00142104270740092";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Cookie", id);

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine("Resultado: " + String.Format("Response: {0}", jsonResponse));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



    }
}
