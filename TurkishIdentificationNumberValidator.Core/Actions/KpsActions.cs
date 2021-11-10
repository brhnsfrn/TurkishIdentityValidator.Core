using System;
using System.Collections.Generic;
using System.Text;

namespace TurkishIdentificationNumberValidator.Core.Actions
{
    public class KpsActions
    {
        private KpsActions() { }
        private static KpsActions _instance;
        public static KpsActions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KpsActions();
                return _instance;
            }
        }
        public string TRKey => "TCKimlikNoDogrula";
        public string TRResult => "TCKimlikNoDogrulaResult";
        public string FRKey => "YabanciKimlikNoDogrula";
        public string FRResult => "YabanciKimlikNoDogrulaResult";
    }
}
