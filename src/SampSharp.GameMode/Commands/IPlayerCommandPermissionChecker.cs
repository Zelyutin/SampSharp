using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Contains the methods of a permission checker for a player command.
    /// </summary>
    public interface IPlayerCommandPermissionChecker
    {
        /// <summary>
        /// Checks whether the specified player has the required permissions to invoke a specific command.
        /// </summary>
        /// <param name="player">The player to check.</param>
        /// <param name="command">The command to check for.</param>
        /// <param name="message">An error message which will be displayed if <c>false</c> is returned. If no message is specified, the command will be ignored.</param>
        /// <returns><c>true</c> if the player is allowed to invoke the command, <c>false</c> if the player does not have the required permissions.</returns>
        bool Check(BasePlayer player, ICommand<BasePlayer> command, ref string message);
    }
}