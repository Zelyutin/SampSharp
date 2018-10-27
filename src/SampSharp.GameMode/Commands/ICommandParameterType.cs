namespace SampSharp.GameMode.Commands
{
    /// <summary>
    ///     Contains the methods of a command parameter type parser
    /// </summary>
    public interface ICommandParameterType
    {
        /// <summary>
        /// Parses the specified command text.
        /// </summary>
        /// <param name="commandText">The command text to parse. If the command has been parsed successfully, the parsed value will be trimmed from the command.</param>
        /// <param name="output">The parsed output.</param>
        /// <param name="error">An error which will be displayed if the parameter value is invalid.</param>
        /// <returns></returns>
        CommandParameterParseResponse Parse(ref string commandText, out object output, out string error);
    }
}