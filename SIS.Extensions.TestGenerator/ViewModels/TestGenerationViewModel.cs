using System;
using System.Windows.Input;
using SIS.Extensions.TestGenerator.Commands;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.ViewModels
{
    public class TestGenerationViewModel : BaseViewModel
    {
        private string _code;
        private readonly IVisualStudioManager _manager;
        private readonly IFileTemplate _fileTemplate;

        public TestGenerationViewModel(IVisualStudioManager manager, IFileTemplate fileTemplate) : base("Generator")
        {
            if (manager == null) throw new ArgumentNullException(nameof(manager));
            if (fileTemplate == null) throw new ArgumentNullException(nameof(fileTemplate));

            _manager = manager;
            _fileTemplate = fileTemplate;
            GenerateCommand = new Command(Generate);
        }

        public string Code
        {
            get { return _code; }
            set { _code = value;  NotifyPropertyChanged(this, x => x.Code); }
        }

        public ICommand GenerateCommand { get; }

        public void Generate(object obj)
        {
            Code = _manager.GenerateUnitTest(_fileTemplate);
        }
    }
}