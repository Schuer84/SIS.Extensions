using System;

namespace SIS.Extensions.TestGenerator.Commands
{
    public class Command : BaseCommand
    {
        private readonly Action<object> _action;

        public Command(Action<object> action)
        {
            _action = action;
        }

        public override void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }
    }
}