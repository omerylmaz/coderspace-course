using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using CourseApp.Domain.Events;
using CourseApp.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace CourseApp.Infrastructure.Messaging.Consumers;

internal class EmailRegisteredEventConsumer : IConsumer<EmailRegisteredEvent>
{
    private readonly EmailOptions _emailOptions;
    private readonly ILogger<EmailRegisteredEventConsumer> _logger;


    public EmailRegisteredEventConsumer(IOptions<EmailOptions> emailOptions, ILogger<EmailRegisteredEventConsumer> logger)
    {
        _emailOptions = emailOptions.Value;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<EmailRegisteredEvent> context)
    {
        var message = context.Message;

        using var smtpClient = new SmtpClient(_emailOptions.Host)
        {
            Port = _emailOptions.Port,
            Credentials = new NetworkCredential(
                _emailOptions.Username,
                _emailOptions.Password
            ),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailOptions.From),
            Subject = message.Subject,
            Body = message.Body,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(message.To);
        await smtpClient.SendMailAsync(mailMessage);

        _logger.LogInformation("Email sent to {To}", message.To);
    }
}
