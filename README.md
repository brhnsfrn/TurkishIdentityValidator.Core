# TurkishIdentityValidator.Core

*Nuget package project for .Net / .Net Core.* 

The identification number validator is a .NET Core packages for verifying turkish identity number using by records office web services.

https://www.nuget.org/packages/TCKimlikNoDogrulama.Core/

# Usage

```csharp      
using TurkishIdentificationNumberValidator.Core;
``` 

```csharp      
bool result = new TurkishIdentityValidator(new IdentityModel{
  IdentityNumber = 38148236746,
  Name = "HÜSEYİN ONUR",
  Surname = "SALİK",
  DateOfBirth = DateTime.Parse("01-01-1970")
}).IsValid();
```
# Lisans

MIT
