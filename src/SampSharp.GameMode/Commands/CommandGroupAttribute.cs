using System;
using System.Collections.Generic;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    ///     Indicates commands within this class or method are part of a command group.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CommandGroupAttribute : Attribute
    {
        private readonly string[] _paths;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandGroupAttribute" /> class.
        /// </summary>
        /// <param name="paths">The relative paths of the command group.</param>
        public CommandGroupAttribute(params string[] paths)
        {
            _paths = paths;
        }

        /// <summary>
        ///     Gets the relative paths of the command group.
        /// </summary>
        public IEnumerable<CommandPath> Paths => ParsePaths();

        private IEnumerable<CommandPath> ParsePaths()
        {
            if (_paths == null)
                yield break;

            foreach (var path in _paths)
            {
                if (CommandPath.TryParse(path, out var result))
                    yield return result;
            }
        }
    }
}