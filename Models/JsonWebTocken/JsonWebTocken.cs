using Microsoft.AspNetCore.WebUtilities;

namespace product_web_app.Models.JsonWebTocken
{
    public class JsonWebTocken
    {
        public Result Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }
}
