
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

namespace Roshtaty.Helpers
{
    public class SmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;

        // تهيئة الخدمة مع الـ IConfiguration
        public SmsService(IConfiguration configuration)
        {
            // قراءة الإعدادات من appsettings.json
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _fromPhoneNumber = configuration["Twilio:FromPhoneNumber"];

            TwilioClient.Init(_accountSid, _authToken);  // تهيئة الاتصال مع Twilio
        }
        public async Task<bool> SendSMS(string toPhoneNumber, string message)
        {
            try
            {
                var messageSent = MessageResource.Create(
                    body: message,
                    from: new Twilio.Types.PhoneNumber(_fromPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(toPhoneNumber)
                );
                return true;  // إذا تم إرسال الرسالة بنجاح
            }
            catch (ApiException ex)
            {
                // إذا حدث خطأ أثناء إرسال الرسالة
                Console.WriteLine($"Error sending SMS: {ex.Message}");
                return false;  // إذا فشل إرسال الرسالة
            }
        }
    }
}
