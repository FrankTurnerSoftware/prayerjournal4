using PrayerJournal.Helpers;

namespace PrayerJournal.ViewModels
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
            _historyButtonText = "See History";
            _currentStatusColour = "LightGreen";
            _currentStatusText = "Current";
            Filename = "c:\\temp\\prayerlist.json";

            // Commands

            SaveFileCommand = new RelayCommand(SaveFile);
            SaveFileAsCommand = new RelayCommand(SaveFileAs);

            AddItemCommand = new RelayCommand(AddItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            MoveItemToHistoryCommand = new RelayCommand(MoveItemToAndFromHistory);
            HistoryToggleCommand = new RelayCommand(ToggleHistory);
            ExitApplicationCommand = new RelayCommand(ExitApplication);

        }
    }
    // TODO - If the list is > 0 items, then select the first item on the list.
}
