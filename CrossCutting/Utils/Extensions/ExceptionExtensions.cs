using System;
using System.Diagnostics;
using System.Text;

namespace Solution.CrossCutting.Utils
{
    public static class ExceptionExtensions
    {
        public static string GetDetail(this Exception exception)
        {
            var sb = new StringBuilder();

            sb.Append("Message: '").Append(exception.Message).Append("'");

            var stackFrame = new StackTrace(exception, true).GetFrame(0);

            if (stackFrame == null)
            {
                return sb.ToString();
            }

            sb.Append(" File: '").Append(stackFrame.GetMethod().DeclaringType).Append("'");

            sb.Append(" Line: '").Append(stackFrame.GetFileLineNumber()).Append("'");

            return sb.ToString();
        }
    }
}
