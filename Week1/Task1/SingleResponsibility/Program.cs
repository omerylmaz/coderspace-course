// See https://aka.ms/new-console-template for more information
using SingleResponsibility.BadCode;
using SingleResponsibility.GoodCode;
using SingleResponsibility.Models;

// Burada SRP ile ilgili gösterdiğim senaryo şu şekilde:
// Burada öncelikle user sisteme kayıt oluyor, Fakat user kayıt olurken aynı zamanda kayıt olmasıyla ilgili doğrulama da aynı metot içerisinden gönderiliyorç
// Yani burada Register metodunun iki görevi oluyor, biri kullanıcının kayıt olması ve diğeri ise doğrulama gönderilmesi.
// Bu durumda ileride gelecekte kullanıcının farklı bir senaryo ile değiştirilmesi gereken bir özellik olduğunda yine register metoduna müdahale etmesi gerekir,
// Fakat bu register metodunun yapması gereken bir sorumluluk değil.
// Benim burada yaptığım bu sorumluluğu başka bir servise yükletmem oldu. İleride diğer doğrulama seçenekleri arasında bir tercih yapılmak istendiğinde tekrardan user servisine gerek duymadan
// ilgili verification servisine müdahale edilebilir.


User user = new User()
{
    Email = "omeryilmaz@gmail.com",
    PhoneNumber = "1234567890",
    Username = "OmerTheWinnder",
};

#region BadCoding


UserServiceBad userServiceBad = new();
userServiceBad.RegisterUser(user);  // Kullanıcı kayıt olmanın yanında aynı zamanda verify olarak email gönderiyor fakat gelecekte verification da değişebilir.

#endregion



#region GoodCoding

UserServiceGood userServiceGood = new();
userServiceGood.RegisterUser(user);  // Kullanıcı sadece kayıt oluyor

VerificationService verificationService = new();  // Verification yöntemlerinden istenenler uygulanıyor
verificationService.VerifyWithSms(user.Email);
verificationService.VerifyWithTwoFactor(user);

#endregion