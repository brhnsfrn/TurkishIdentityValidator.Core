# TurkishIdentityValidator.Core

*Nuget package project for .Net / .Net Core.* 

The identification number validator is a .NET Core packages for verifying turkish identity number using by records office web services.

https://www.nuget.org/packages/TurkishIdentificationNumberValidator.Core/

# Usage

```csharp      
using TurkishIdentificationNumberValidator.Core;
``` 

```csharp      
bool result = new TurkishIdentityValidator(new IdentityModel{
  IdentityNumber = 10000000146,
  Name = "GAZİ MUSTAFA KEMAL",
  Surname = "ATATÜRK",
  DateOfBirth = DateTime.Parse("01-01-1881")
}).IsValid();
```
# Lisans

MIT
