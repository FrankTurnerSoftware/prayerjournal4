using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrayerJournal4.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            ExitApplicationCommand = new RelayCommand(ExitApplication);
        }
    }
}
