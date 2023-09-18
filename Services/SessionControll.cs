using product_web_app.Models.JsonWebTocken;

namespace product_web_app.Services
{
    public class SessionControll : ISessionControl
    {
        private bool isLoggedIn = false;
        private JsonWebTocken _jwt = new JsonWebTocken();
        public string GetAccessTocken()
        {
            return _jwt.Result.AccessToken;
        }

        public bool IsLoggedIn()
        {
            return isLoggedIn;
        }

        public void SetJWT(JsonWebTocken jwt)
        {
            this._jwt = jwt;

            if( jwt.Success )
            {
                this.isLoggedIn = true;
            }

        }
    }
}
