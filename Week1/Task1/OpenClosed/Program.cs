// See https://aka.ms/new-console-template for more information
using OpenClosed.BadCode;
using OpenClosed.GoodCode;

Console.WriteLine("Hello, World!");

#region BadCodePart
PaymentServiceBad paymentServiceBad = new PaymentServiceBad();
paymentServiceBad.Pay(PaymentMethods.DoorPayment, 500);
#endregion

#region GoodCodePart
PaymentServiceGood paymentServiceGood = new PaymentServiceGood();
paymentServiceGood.Pay(500, new DoorPayment());   // Burada new'lemeyi aradan çıkarmak için factory method design pattern uygulayabiliriz, fakat bu part OCP'ye odaklı olsun diye detaylandırmadım.
#endregion
