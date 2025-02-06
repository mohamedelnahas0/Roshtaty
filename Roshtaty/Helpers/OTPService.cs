namespace Roshtaty.Helpers
{
    public class OTPService
    {
        private readonly Dictionary<string, string> _otpStore = new Dictionary<string, string>();

        public string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); 
        }

        public void StoreOTP(string phoneNumber, string otp)
        {
            _otpStore[phoneNumber] = otp;
        }

        public bool ValidateOTP(string phoneNumber, string otp)
        {
            return _otpStore.ContainsKey(phoneNumber) && _otpStore[phoneNumber] == otp;
        }
    }
}
