using System.Collections.Generic;

namespace Solution.CrossCutting.Utils
{
    public sealed class ValidatorResult
    {
        public IDictionary<string, string> Errors { get; } = new Dictionary<string, string>();

        public bool IsValid => Errors == null || Errors.Count == 0;
    }
}
