using System.ComponentModel;

namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }
    }
}