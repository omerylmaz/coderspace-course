using OpenClosed.BadCode;

namespace OpenClosed.GoodCode;

internal class PaymentServiceGood
{
    public void Pay(int amount, IPayment payment)
    {
        payment.Pay(amount);
        // Burada dışarıdan sadece interface alarak ilgili servisin işlemlerini buradaki koda müdahale etmeden direk gerçekleştirebiliriz
    }
}
