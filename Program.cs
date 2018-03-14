using Newtonsoft.Json.Linq;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.RequestHandlers;
using System;

namespace RESTfulAPIConsume
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching the list of RestSharp releases and their publish dates.");
            Console.WriteLine();

            //These are the five ways to consume RESTful APIs described in the blog post
            IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();

            //Results should be the same
            var releases = GetReleases(httpClientRequestHandler);

            Console.WriteLine("Release: {0}", releases);

            Console.ReadLine();
        }

        public static JToken GetReleases(IRequestHandler requestHandler)
        {
            return requestHandler.CallAPI("/api/HoaDonDienTu/Update?id={0}&invoicestatus={1}&signstatus={2}", "4b2bca69-1157-4d20-971b-d16773f3bb25","21","21");

        }
    }
}
