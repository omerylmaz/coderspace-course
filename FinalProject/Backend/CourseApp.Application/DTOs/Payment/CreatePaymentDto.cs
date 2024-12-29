using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record CreatePaymentDto(
    string CardHolderName,
    string CardNumber,
    string ExpireMonth,
    string ExpireYear,
    string Cvc,
    string BuyerId,
    string BuyerName,
    string BuyerSurname,
    string BuyerGsmNumber,
    string BuyerEmail,
    string CourseId,
    string CourseName,
    string CategoryName,
    decimal Price
);