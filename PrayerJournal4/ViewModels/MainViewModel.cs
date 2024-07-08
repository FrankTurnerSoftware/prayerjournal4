using PrayerJournal4.Helpers;
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
            // Data
            GenerateTestItems testItems = new GenerateTestItems();
            CurrentItems = testItems.CurrentItems;
            HistoryItems = testItems.HistoryItems;

            // Properties
            _displayHistoryList = false;
            
            // Commands
            AddItemCommand = new RelayCommand(AddItem);
            ExitApplicationCommand = new RelayCommand(ExitApplication);
        }
    }
}
