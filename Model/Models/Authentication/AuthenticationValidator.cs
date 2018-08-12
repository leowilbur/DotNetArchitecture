using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;

namespace Solution.Model.Models
{
    public sealed class AuthenticationValidator : Validator<AuthenticationModel>
    {
        public override ValidatorResult Validate(AuthenticationModel obj)
        {
            var result = new ValidatorResult();

            if (obj == null || string.IsNullOrEmpty(obj.Login) || string.IsNullOrEmpty(obj.Password))
            {
                result.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
            }

            return result;
        }
    }
}
