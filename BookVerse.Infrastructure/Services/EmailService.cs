using System.Net;
using System.Net.Mail;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookVerse.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly EmailOptions _emailOptions;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IOptions<EmailOptions> emailOptions, ILogger<EmailService> logger)
    {
        _emailOptions = emailOptions.Value;
        _logger = logger;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body,CancellationToken cancellationToken)
    {
        using var message = new MailMessage
        {
            From = new MailAddress(_emailOptions.FromEmail, _emailOptions.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = false
        };
        message.To.Add(toEmail);

        using var smtp = new SmtpClient(_emailOptions.SmtpHost, _emailOptions.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailOptions.SmtpUsername, _emailOptions.SmtpPassword),
            EnableSsl = true
        };
        await smtp.SendMailAsync(message, cancellationToken);
        _logger.LogInformation($"Email send successfully to {toEmail}.");
    }
}