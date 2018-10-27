namespace SampSharp.GameMode.Commands
{
    public interface ICommand<in TContext>
    {
        CommandInvokable CanInvoke(TContext context, string command);

        bool Invoke(TContext context, string commandText);
    }
}