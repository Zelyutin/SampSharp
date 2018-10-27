using System;
using System.Linq;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Represents the path of a command.
    /// </summary>
    public struct CommandPath
    {
        private static readonly char[] Whitespace = { ' ', '\t', '\n', '\r' };

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the length.
        /// </summary>
        public int Length => Path?.Length ?? 0;

        /// <summary>
        /// Attempts to parse the specified path string to a <see cref="CommandPath"/> value.
        /// </summary>
        /// <param name="path">The path to parse.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if the value has successfully been parsed; <c>false</c> otherwise.</returns>
        public static bool TryParse(string path, out CommandPath result)
        {
            result = new CommandPath();

            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            var words = path.Split(Whitespace)
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToArray();

            if (words.Length <= 0)
            {
                return false;
            }

            result.Path = string.Join(" ", words);
            result.Name = words.Last();
            return true;
        }

        /// <summary>
        /// Concatenates the specified path to this path.
        /// </summary>
        /// <param name="path">The path to concatenate.</param>
        /// <returns>The concatenated path.</returns>
        public CommandPath Concat(CommandPath path)
        {
            if (Path == null || Name == null)
                return path;
            
            if (path.Path == null || path.Name == null)
                return this;

            var result = new CommandPath
            {
                Name = path.Name,
                Path = Path + " " + path.Path
            };

            return result;
        }

        /// <summary>
        /// Matches the specified command text against this command path.
        /// </summary>
        /// <param name="commandText">The command text to match.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the case of the command text is ignored.</param>
        /// <returns></returns>
        public bool Match(string commandText, bool ignoreCase = true)
        {
            if (commandText == null || commandText.Length < Length)
                return false;

            return commandText.StartsWith(Path, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        #region Overrides of ValueType

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Path ?? string.Empty;
        }

        #endregion
    }
}