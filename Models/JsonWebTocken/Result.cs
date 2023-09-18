namespace product_web_app.Models.JsonWebTocken
{
    public class Result
    {
        public string AccessToken { get; set; }
        public string EncryptedAccessToken { get; set; }
        public int ExpireInSeconds { get; set; }
        public bool ShouldResetPassword { get; set; }
        public string PasswordResetCode { get; set; }
        public int UserId { get; set; }
        public bool RequiresTwoFactorVerification { get; set; }
        public string TwoFactorAuthProviders { get; set; }
        public string TwoFactorRememberClientToken { get; set; }
        public string ReturnUrl { get; set; }
        public string RefreshToken { get; set; }
        public int RefreshTokenExpireInSeconds { get; set; }


    }
}
