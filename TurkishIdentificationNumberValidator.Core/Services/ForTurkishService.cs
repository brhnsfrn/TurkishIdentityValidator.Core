using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurkishIdentificationNumberValidator.Core.Actions;
using TurkishIdentificationNumberValidator.Core.Models;

namespace TurkishIdentificationNumberValidator.Core
{
    public class ForTurkishService
    {
        private long IdentityNumber { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private int BirthYear { get; set; }

        public ForTurkishService(IdentityModel model)
        {
            this.IdentityNumber = model.IdentityNumber;
            this.Name = model.Name.Trim().ToUpper();
            this.Surname = model.Surname.Trim().ToUpper();
            this.BirthYear = model.DateOfBirth.Year;
        }

        public bool Validate()
        {
            XDocument soapRequest = CreateRequestXML();
            HttpResponseMessage response = CreateHttpRequest(soapRequest);

            Task<Stream> streamTask = response.Content.ReadAsStreamAsync();
            Stream stream = streamTask.Result;
            var sr = new StreamReader(stream);
            var soapResponse = XDocument.Load(sr);

            return CreateResponse(soapResponse);
        }

        private HttpResponseMessage CreateHttpRequest(XDocument soapRequest)
        {
            using (var client = new HttpClient(new HttpClientHandler(), false) { Timeout = TimeSpan.FromMinutes(1) })
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = BaseSoapNamespace.TRUri,
                    Method = HttpMethod.Post
                };

                request.Content = new StringContent(soapRequest.ToString(), Encoding.UTF8, "text/xml");

                request.Headers.Clear();
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                request.Headers.Add("SOAPaction", BaseSoapNamespace.Temp.NamespaceName + "/" + KpsActions.Instance.TRKey);

                return client.SendAsync(request).Result;
            }
        }

        private XDocument CreateRequestXML()
        {
            XNamespace xsi = BaseSoapNamespace.Temp;
            return new XDocument(
               new XElement(BaseSoapNamespace.Soapenv + "Envelope",
                   new XAttribute(XNamespace.Xmlns + "soapenv", BaseSoapNamespace.Soapenv),
                   new XAttribute(XNamespace.Xmlns + "ws", xsi),
                   new XElement(BaseSoapNamespace.Soapenv + "Header"),
                   new XElement(BaseSoapNamespace.Soapenv + "Body",
                   new XElement(xsi + KpsActions.Instance.TRKey,
                               new XElement(xsi + "TCKimlikNo", this.IdentityNumber),
                               new XElement(xsi + "Ad", this.Name),
                               new XElement(xsi + "Soyad", this.Surname),
                               new XElement(xsi + "DogumYili", this.BirthYear))
                   )
               ));
        }

        private bool CreateResponse(XDocument xDocument)
        {
            var result = xDocument.Descendants().SingleOrDefault(x => x.Name.LocalName == KpsActions.Instance.TRResult).Value;
            return bool.Parse(result);
        }
    }
}
