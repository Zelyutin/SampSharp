using System;
using System.Reflection;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Contains the methods of a command service.
    /// </summary>
    /// <typeparam name="TCommand">The type of the commands to be invoked.</typeparam>
    /// <typeparam name="TContext">The type of the context in which commands are invoked.</typeparam>
    public interface ICommandService<in TCommand, in TContext> where TCommand : class, ICommand<TContext>
    {
        /// <summary>
        /// Registers the specified command.
        /// </summary>
        /// <param name="command">The command to register.</param>
        void Register(TCommand command);

        /// <summary>
        /// Finds and invokes a command with the specifeid command text.
        /// </summary>
        /// <param name="context">The context of the command execution.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        bool Invoke(TContext context, string commandText);

        /// <summary>
        /// Registers the commands in the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to scan for commands.</param>
        void RegisterCommands(Assembly assembly);


        /// <summary>
        /// Registers the commands in the assembly of the specified type.
        /// </summary>
        /// <param name="typeInAssembly">A type in the assembly to scan for commands.</param>
        void RegisterCommands(Type typeInAssembly);

        /// <summary>
        /// Registers the commands in the assembly of the specified type.
        /// </summary>
        /// <typeparam name="TAssembly">A type in the assembly to scan for commands.</typeparam>
        void RegisterCommands<TAssembly>();

    }
}