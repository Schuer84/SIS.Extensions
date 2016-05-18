using System.Windows.Input;
using SIS.Extensions.TestGenerator.Commands;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.ViewModels
{
    public class ContainerViewModel : BaseViewModel
    {
        private ICommand _select;
        private IViewModel _model;

        public ContainerViewModel(params IViewModel[] args) : base("Container")
        {
            Models = args;
            Model = args[0];
        }

        public IViewModel[] Models { get; set; }
        public IViewModel Model
        {
            get { return _model; }
            set { _model = value;  NotifyPropertyChanged(this, x => x.Model); }
        }

        public ICommand Select
        {
            get { return _select ?? (_select = new Command(x => Model = x as IViewModel)); }
        }

    }
}