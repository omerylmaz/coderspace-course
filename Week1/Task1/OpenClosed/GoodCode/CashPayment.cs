namespace OpenClosed.GoodCode;

internal class CashPayment : IPayment
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Cash payment: {amount}");
    }
}
