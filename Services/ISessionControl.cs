using product_web_app.Models.JsonWebTocken;

namespace product_web_app.Services
{
    public interface ISessionControl
    {
        bool IsLoggedIn();
        void SetJWT(JsonWebTocken jwt);
        string GetAccessTocken();
    }
}
