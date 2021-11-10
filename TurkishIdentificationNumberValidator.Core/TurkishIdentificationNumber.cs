using System;
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
    public class TurkishIdentityValidator
    {
        private IdentityModel Model;

        /// <summary>
        /// The identification number validator is a .NET Core packages for verifying turkish identity using by records office web services.
        /// </summary>
        /// <param name="model"></param>
        public TurkishIdentityValidator(IdentityModel model)
        {
            this.Model = model;
        }

        public bool IsValid()
        {
            if(this.Model.IdentityNumber.ToString().StartsWith("99") || this.Model.IdentityNumber.ToString().StartsWith("997"))
            {
                return new ForForeignersService(this.Model).Validate();
            }
            else
            {
                return new ForTurkishService(this.Model).Validate();
            }
        }
    }
}
