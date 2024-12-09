namespace BlazorASG
{
    public class SessionManger
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManger(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetSessionData(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string GetSessionData(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
