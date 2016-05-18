using System;
using System.Threading.Tasks;

namespace SIS.Extensions.TestGenerator.Commands
{
    public class AsyncCommand : BaseCommand
    {
        private readonly Func<Task> _provider;

        public AsyncCommand(Func<Task> provider)
        {
            _provider = provider;
        }

        public Task Execute()
        {
            return _provider.Invoke();
        }
        public override async void Execute(object parameter)
        {
            await Execute();
        }
    }
}