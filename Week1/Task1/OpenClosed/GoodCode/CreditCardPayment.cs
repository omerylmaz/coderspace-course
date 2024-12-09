using OpenClosed.GoodCode;

namespace OpenClosed.GoodCode;

public class CreditCardPayment : IPayment
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Credit Card payment: {amount}");
    }
}
