namespace Roshtaty.Helpers
{
    public interface ISmsService
    {
        Task<bool> SendSMS(string toPhoneNumber, string message);
    }
}
