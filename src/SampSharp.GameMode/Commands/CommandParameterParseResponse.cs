using System;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Indicates whether a command parameter has been parsed successfully.
    /// </summary>
    [Flags]
    public enum CommandParameterParseResponse
    {
        /// <summary>
        ///     The parameter has been parsed successfully.
        /// </summary>
        Success = 1,

        /// <summary>
        ///     The command text is not suitable for this command parameter.
        /// </summary>
        Failure = 2,

        /// <summary>
        ///     The command text is properly formated, but the value is not valid. If an error has been returned by the
        ///     <see cref="ICommandParameterType" />, it will be displayed.
        /// </summary>
        InvalidValue = Success | Failure
    }
}