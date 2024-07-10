using PrayerJournal.Helpers;
using PrayerJournal.Models;
using System.Collections.ObjectModel;

namespace PrayerJournal.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            // Data
            //GenerateTestItems testItems = new GenerateTestItems();
            //CurrentItems = testItems.CurrentItems;
            //HistoryItems = testItems.HistoryItems;

            CurrentItems = new ObservableCollection<PrayerItem>();
            HistoryItems = new ObservableCollection<PrayerItem>();

            // Properties
            _displayHistoryList = false;
            _historyButtonText = "See History";
            _currentStatusColour = "LightGreen";
            _currentStatusText = "Current";
            Filename = null;

            // Commands
            OpenFileCommand = new RelayCommand(OpenFile);
            NewFileCommand = new RelayCommand(NewFile);
            SaveFileCommand = new RelayCommand(SaveFile);
            SaveFileAsCommand = new RelayCommand(SaveFileAs);
            ExitApplicationCommand = new RelayCommand(ExitApplication);

            AddItemCommand = new RelayCommand(AddItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            MoveItemToHistoryCommand = new RelayCommand(MoveItemToAndFromHistory);
            HistoryToggleCommand = new RelayCommand(ToggleHistory);

            // Start-up
            LoadLastOpenedFile();
        }
    }
    // TODO - If the list is > 0 items, then select the first item on the list.
}
