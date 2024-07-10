using PrayerJournal.Models;
using System.Collections.ObjectModel;

namespace PrayerJournal.ViewModels
{
    public partial class MainViewModel
    {
        private bool _displayHistoryList;
        private PrayerItem _selectedItem;
        private string _historyButtonText;
        private string _currentStatusColour;
        private string _currentStatusText;
        private string _filename;
        private int _selectedIndex;
        private ObservableCollection<PrayerItem> _currentItems;
        private ObservableCollection<PrayerItem> _historyItems;

        public ObservableCollection<PrayerItem> PrayerListToDisplay => DisplayHistoryList ? HistoryItems : CurrentItems;

        public ObservableCollection<PrayerItem> CurrentItems
        {
            get => _currentItems;
            set
            {
                _currentItems = value;
                OnPropertyChanged(nameof(HistoryItems));
                OnPropertyChanged(nameof(PrayerListToDisplay));
            }
        }
        public ObservableCollection<PrayerItem> HistoryItems
        {
            get => _historyItems;
            set
            {
                _historyItems = value;
                OnPropertyChanged(nameof(HistoryItems));
                OnPropertyChanged(nameof(PrayerListToDisplay));
            }
        }

        public bool DisplayHistoryList
        {
            get => _displayHistoryList;
            set
            {
                if (_displayHistoryList != value)
                {
                    _displayHistoryList = value;
                    OnPropertyChanged("DisplayHistoryList");
                    OnPropertyChanged("PrayerListToDisplay");
                }
            }
        }

        public bool IsItemSelected => SelectedItem != null;

        public PrayerItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    OnPropertyChanged("IsItemSelected");
                }
            }
        }
        public string HistoryButtonText
        {
            get => _historyButtonText;
            set
            {
                if (_historyButtonText != value)
                {
                    _historyButtonText = value;
                    OnPropertyChanged("HistoryButtonText");
                }
            }
        }

        public string CurrentStatusText
        {
            get => _currentStatusText;
            set
            {
                if (_currentStatusText != value)
                {
                    _currentStatusText = value;
                    OnPropertyChanged("CurrentStatusText");
                }
            }
        }

        public string CurrentStatusColour
        {
            get => _currentStatusColour;
            set
            {
                if (_currentStatusColour != value)
                {
                    _currentStatusColour = value;
                    OnPropertyChanged("CurrentStatusColour");
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }
        }

        public string Filename
        {
            get => _filename;
            set
            {
                if (_filename != value)
                {
                    _filename = value;
                    OnPropertyChanged(nameof(Filename));
                }
            }
        }
    }
}
