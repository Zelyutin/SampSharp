// SampSharp
// Copyright 2018 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Commands
{
    /// <summary>
    /// Contains the definition of a detected command.
    /// </summary>
    public struct DetectedCommandDefinition
    {
        public CommandPath Path { get; }

        public ICommandParameterType[] Parameters { get; }
    }

    public abstract class CommandService<TCommand, TContext> : ICommandService<TCommand, TContext> where TCommand : class, ICommand<TContext>
    {
        private readonly List<TCommand> _commands = new List<TCommand>();

        protected CommandService()
        {
            Commands = _commands.AsReadOnly();
        }

        public virtual IReadOnlyList<TCommand> Commands { get; }

        public virtual bool Remove(TCommand command)
        {
            return _commands.Remove(command);
        }

        public void RegisterCommands(Type typeInAssembly)
        {
            if (typeInAssembly == null) throw new ArgumentNullException(nameof(typeInAssembly));

            RegisterCommands(typeInAssembly.GetTypeInfo().Assembly);
        }

        public void RegisterCommands<TAssembly>()
        {
            RegisterCommands(typeof(TAssembly).GetTypeInfo().Assembly);
        }

        public virtual void Register(TCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _commands.Add(command);
        }

        public virtual ICommand<TContext> GetCommandForCommandText(TContext context, string commandText)
        {
            TCommand lastResort = null;
            
            foreach (var command in _commands)
            {
                switch (command.CanInvoke(context, commandText))
                {
                    case CommandInvokable.Yes:
                        return command;
                    case CommandInvokable.LastResort:
                        lastResort = command;
                        break;
                }
            }

            return lastResort;
        }

        public virtual bool Invoke(TContext context, string commandText)
        {
            var command = GetCommandForCommandText(context, commandText);

            return command?.Invoke(context, commandText) ?? false;
        }

        public virtual void RegisterCommands(Assembly assembly)
        {
            assembly.GetTypes()
                .Where(t => t.GetTypeInfo().IsInterface && t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract);
            

            // TODO...
        }
    }

    public class PlayerCommandService : CommandService<IPlayerCommand, BasePlayer>
    {
    }
}