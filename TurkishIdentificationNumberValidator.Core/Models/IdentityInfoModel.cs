using System;
using System.Collections.Generic;
using System.Text;

namespace TurkishIdentificationNumberValidator.Core
{
    public class IdentityModel
    {
        /// <summary>
        /// Unique 11-digit number
        /// </summary>
        public long IdentityNumber { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
