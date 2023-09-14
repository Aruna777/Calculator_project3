using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class HistoryViewModels : ObservableObject, INotifyPropertyChanged
    {
     
    public event PropertyChangedEventHandler PropertyChanged;
         

        private ObservableCollection<String> HistoryExpressions;

        public HistoryViewModels()
        {
            HistoryExpressions = new ObservableCollection<String>();
        }

        public void AddtoHistory(String Calculation)
        {
            HistoryExpressions.Add(Calculation);
            OnPropertyChanged("history");
            OnPropertyChanged();
        }

        public ObservableCollection<String> history
        {
            get => HistoryExpressions;
        }




        public void OnPropertyChanged([CallerMemberName] string e = "")
               => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e));
    }
}
