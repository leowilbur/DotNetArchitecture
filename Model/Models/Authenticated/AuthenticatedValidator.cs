using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;

namespace Solution.Model.Models
{
    public sealed class AuthenticatedValidator : Validator<AuthenticatedModel>
    {
        public override ValidatorResult Validate(AuthenticatedModel obj)
        {
            var result = new ValidatorResult();

            if (obj == null || obj.UserId == 0)
            {
                result.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
            }

            return result;
        }
    }
}
