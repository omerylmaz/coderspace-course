
namespace OpenClosed.BadCode;

internal class PaymentServiceBad
{
    public void Pay(PaymentMethods paymentMethod, int amount)
    {
        if (paymentMethod == PaymentMethods.CreditCard)
        {
            Console.WriteLine($"Credit Card payment: {amount}");
        }
        else if (paymentMethod == PaymentMethods.Cash)
        {
            Console.WriteLine($"Cash payment: {amount}");
        }
        else if (paymentMethod == PaymentMethods.DoorPayment)
        {
            Console.WriteLine($"Door payment: {amount}");
        }
        // Yeni bir ödeme sistemi eklemek istediğim zaman buraya tekrardan kodun içine müdahale ederek onun için de bir if else yapısı kurmamız gerekecek.
        // Mesela BTC ödeme getirmek istersem onun için de bir ek koşul yazmam gerekecek.
    }
}
