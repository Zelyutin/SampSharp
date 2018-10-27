namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Contains values indicating whether a command can be invoked.
    /// </summary>
    public enum CommandInvokable
    {
        /// <summary>
        /// The command can be invoked.
        /// </summary>
        Yes,
        /// <summary>
        /// The command cannot be invoked.
        /// </summary>
        No,
        /// <summary>
        /// The command should only be invoked if no other command returns <see cref="Yes"/>.
        /// </summary>
        LastResort
    }
}