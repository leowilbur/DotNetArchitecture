using System;

namespace Solution.CrossCutting.Logging
{
    public interface ILogger
    {
        void Error(string message);

        void Error(Exception exception);

        void Information(string message);
    }
}
