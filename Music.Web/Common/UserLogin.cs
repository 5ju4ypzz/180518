using System;

namespace Music.Web.Common
{
    [Serializable]
    public class UserLogin
    {
        public int user_id { get; set; }
        public string email { get; set; }
    }
}