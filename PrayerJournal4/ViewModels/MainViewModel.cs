using PrayerJournal4.Helpers;

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
            _historyButtonText = "See History";

            // Commands
            AddItemCommand = new RelayCommand(AddItem);
            HistoryToggleCommand = new RelayCommand(ToggleHistory);
            ExitApplicationCommand = new RelayCommand(ExitApplication);
        }
    }
    // TODO - If the list is > 0 items, then select the first item on the list.
}
