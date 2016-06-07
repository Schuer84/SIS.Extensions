using System;
using System.Windows;
using System.Windows.Input;
using SIS.Extensions.TestGenerator.Commands;
using SIS.Extensions.TestGenerator.Contracts;
using SIS.Extensions.TestGenerator.Managers;

namespace SIS.Extensions.TestGenerator.ViewModels
{
    public class TestGenerationViewModel : BaseViewModel
    {
        private string _code;
        private readonly IVisualStudioManager _manager;
        private bool _copyToClipboard = true;


        public TestGenerationViewModel(IVisualStudioManager manager) : base("Generator")
        {
            if (manager == null) throw new ArgumentNullException(nameof(manager));

            _manager = manager;
            GenerateCommand = new Command(Generate);
            CopyCommand = new Command(Copy);
        }

        public bool CopyToClipboard
        {
            get { return _copyToClipboard; }
            set { _copyToClipboard = value; NotifyPropertyChanged(this, x => x.CopyToClipboard); }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value;  NotifyPropertyChanged(this, x => x.Code); }
        }

        public ICommand GenerateCommand { get; }
        public ICommand CopyCommand { get; }

        public void Copy(object obj)
        {
            Clipboard.SetText(Code);
        }
        public void Generate(object obj)
        {
            Code = _manager.GenerateUnitTest();

            if (CopyToClipboard)
            {
                Copy(Code);
            }
        }
    }
}