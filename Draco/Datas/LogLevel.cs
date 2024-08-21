using System;
using System.Collections.Generic;
using System.Text;

namespace Draco.Datas
{
    /// <summary>
    /// Enumerates the possible severity levels for a log message.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// This log message contains information. Low severity.
        /// </summary>
        Information,

        /// <summary>
        /// This log message contains a warning. Medium severity.
        /// </summary>
        Warning,

        /// <summary>
        /// This log message contains an error. High severity.
        /// </summary>
        Error,

        /// <summary>
        /// This log message contains an exception. Extreme severity.
        /// </summary>
        Exception
    }
}
