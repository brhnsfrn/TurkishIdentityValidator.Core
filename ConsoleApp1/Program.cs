using System;
using TurkishIdentificationNumberValidator.Core;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new TurkishIdentityValidator(new IdentityModel { IdentityNumber = 36019712986, Surname = "Safran", Name = "Burhan", DateOfBirth = DateTime.Parse("13-08-1998") }).IsValid();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
