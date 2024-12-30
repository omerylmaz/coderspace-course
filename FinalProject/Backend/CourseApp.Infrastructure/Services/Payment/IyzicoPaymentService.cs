using CourseApp.Application.Abstractions.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CourseApp.Infrastructure.Services.Payment;

internal class IyzicoPaymentService(IHttpContextAccessor httpContextAccessor) : IPaymentService
{
    public async Task<string> Pay(CreatePaymentDto paymentDto, CancellationToken cancellationToken)
    {
        Options options = new()
        {
            ApiKey = "sandbox-aPK7OfgfsDXbiUT4uOVVfS87hrfaYnyX",
            SecretKey = "sandbox-iQLWUStSDtwRoQh4iJx2mYPBphi1Cmcy",
            BaseUrl = "https://sandbox-api.iyzipay.com"
        };

        var httpRequest = httpContextAccessor.HttpContext?.Request;
        var baseUrl = $"{httpRequest?.Scheme}://{httpRequest?.Host}";

        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = paymentDto.PaymentId.ToString();
        request.Price = paymentDto.Price.ToString(CultureInfo.InvariantCulture);
        request.PaidPrice = paymentDto.Price.ToString(CultureInfo.InvariantCulture);
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = Guid.NewGuid().ToString();
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.SUBSCRIPTION.ToString();
        request.CallbackUrl = $"{baseUrl}/api/payments/paycallback";

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = paymentDto.CardHolderName;
        paymentCard.CardNumber = paymentDto.CardNumber;
        paymentCard.ExpireMonth = paymentDto.ExpireMonth;
        paymentCard.ExpireYear = paymentDto.ExpireYear;
        paymentCard.Cvc = paymentDto.Cvc;
        paymentCard.RegisterCard = 0;
        request.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = paymentDto.BuyerId;
        buyer.Name = paymentDto.BuyerName;
        buyer.Surname = paymentDto.BuyerSurname;
        buyer.GsmNumber = paymentDto.BuyerGsmNumber;
        buyer.Email = paymentDto.BuyerEmail;
        buyer.IdentityNumber = "74300864791";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        request.Buyer = buyer;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        request.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = paymentDto.CourseId;
        firstBasketItem.Name = paymentDto.CourseName;
        firstBasketItem.Category1 = paymentDto.CategoryName;
        firstBasketItem.Category2 = paymentDto.CategoryName;
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = paymentDto.Price.ToString(CultureInfo.InvariantCulture);
        basketItems.Add(firstBasketItem);

        request.BasketItems = basketItems;

        ThreedsInitialize threedsInitialize = await ThreedsInitialize.Create(request, options);

        return threedsInitialize.HtmlContent;
    }
}
