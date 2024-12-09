// See https://aka.ms/new-console-template for more information
using LiskovSubstitution.GoodCode;
using BadCode = LiskovSubstitution.BadCode;
using GoodCode = LiskovSubstitution.GoodCode;


#region BadCode
// Burada aslında yaptığım 3 tane login olma şekli yapmaktı. Bunlardan biri Google ile biri Facebook üzerinden bir diğeri ise normal kendi auth sistemimiz üzerinden giriş yapmaktı.
// Fakat varsaydığım senaryoda Facebook üzerinden kullanıcının detayı yoktu ve IAuth üzerinden implemente edildiği için kullanıcı daha sonrasında facebook üzerinden giriş yapıp
// bilgilerini görmek istediğinde facebook servisinde implement edilmediği için hata verecektir.
BadCode.IAuth authBad = new BadCode.GoogleAuth();
authBad.Login("omer", "123");
var userBad = authBad.GetProfileDetails(1);
Console.WriteLine($"User Details: {userBad.Id}, {userBad.Name}, {userBad.Email}");
authBad.Logout("omer");



BadCode.IAuth authBadFace = new BadCode.FaceBookAuth();
authBadFace.Login("omer", "123");
var userBadFace = authBadFace.GetProfileDetails(1);
Console.WriteLine($"User Details: {userBadFace.Id}, {userBadFace.Name}, {userBadFace.Email}");
authBadFace.Logout("omer");
#endregion


#region GoodCode
GoodCode.IAuth authGood = new GoodCode.GoogleAuth();
authBad.Login("omer", "123");
IUser userGoogle = new GoodCode.GoogleAuth();
var userGood = userGoogle.GetProfileDetails(1);
Console.WriteLine($"User Details: {userGood.Id}, {userGood.Name}, {userGood.Email}");

GoodCode.NormalAuth authNormal = new GoodCode.NormalAuth();
authNormal.Login("omer", "123");
IUser userLocal = new GoodCode.NormalAuth();
var userNormal = userLocal.GetProfileDetails(1);
Console.WriteLine($"User Details: {userNormal.Id}, {userNormal.Name}, {userNormal.Email}");



//GoodCode.FaceBookAuth authGoodFace = new GoodCode.FaceBookAuth();
//authGoodFace.Login("omer", "123");
//var userGoodFace = authGoodFace.GetProfileDetails(1);
//Console.WriteLine($"User Details: {userGoodFace.Id}, {userGoodFace.Name}, {userGoodFace.Email}");
#endregion