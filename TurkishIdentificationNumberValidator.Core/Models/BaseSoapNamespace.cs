using System;
using System.Xml.Linq;

namespace TurkishIdentificationNumberValidator.Core.Models
{
    public static class BaseSoapNamespace
    {
        public static readonly Uri TRUri = new Uri("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx");
        public static readonly Uri FRUri = new Uri("https://tckimlik.nvi.gov.tr/Service/KPSPublicYabanciDogrula.asmx");
        public static readonly XNamespace Soapenv = "http://www.w3.org/2003/05/soap-envelope";
        public static readonly XNamespace Temp = "http://tckimlik.nvi.gov.tr/WS";
    }
}
