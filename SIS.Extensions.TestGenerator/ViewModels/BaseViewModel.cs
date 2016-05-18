using System;
using System.ComponentModel;
using System.Linq.Expressions;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        private string _title;

        public BaseViewModel(string title)
        {
            _title = title;
        }
        
        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged(this, x => x.Title); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged<TModel, TProp>(TModel sender, Expression<Func<TModel, TProp>> expr)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(sender, new PropertyChangedEventArgs(expr.GetName()));
        }
    }
}
