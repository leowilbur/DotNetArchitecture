using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Solution.CrossCutting.Security
{
    public static class JsonWebTokenSettings
    {
        private static SecurityKey _securityKey;

        public static string Audience => nameof(Audience);

        public static DateTime Expires => DateTime.UtcNow.AddDays(1);

        public static string Issuer => nameof(Issuer);

        public static string Key => Guid.NewGuid() + DateTime.UtcNow.ToString();

        public static SecurityKey SecurityKey => _securityKey ?? (_securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)));

        public static SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);
    }
}
