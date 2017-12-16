using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace GarduinoAPI.Models
{
    public class User : AuthUserSession
    {
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
}