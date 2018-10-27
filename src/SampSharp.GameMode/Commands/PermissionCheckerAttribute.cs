using System;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    ///     Indicates which permission checkers are required for this command path.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionCheckerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionCheckerAttribute"/> class.
        /// </summary>
        /// <param name="permissionCheckerTypes">The permission checker types.</param>
        public PermissionCheckerAttribute(params Type[] permissionCheckerTypes)
        {
            PermissionCheckerTypes = permissionCheckerTypes;
        }

        /// <summary>
        /// Gets the permission checker types.
        /// </summary>
        public Type[] PermissionCheckerTypes { get; }
    }
}