using System;

namespace SampSharp.GameMode.Commands
{
    public class Command<TContext> : ICommand<TContext>
    {
        #region Implementation of ICommand<in TContext>

        public virtual CommandInvokable CanInvoke(TContext context, string command)
        {
            throw new NotImplementedException();
        }

        public virtual bool Invoke(TContext context, string commandText)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}