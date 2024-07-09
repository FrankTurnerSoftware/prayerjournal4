﻿using PrayerJournal4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrayerJournal4.ViewModels
{
    public partial class MainViewModel
    {
        private bool _displayHistoryList;
        private PrayerItem _selectedItem;
        private string _historyButtonText;
        private string _currentStatusColour;
        private string _currentStatusText;

        public ObservableCollection<PrayerItem> CurrentItems { get; set; }
        public ObservableCollection<PrayerItem> HistoryItems { get; set; }

        public ObservableCollection<PrayerItem> PrayerListToDisplay => DisplayHistoryList ? HistoryItems : CurrentItems;

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

        public PrayerItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
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
    }
}
