using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrayerJournal4.ViewModels
{
    public partial class MainViewModel
    {
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand MoveItemToHistoryCommand { get; }
        public ICommand HistoryToggleCommand {  get; }

        public ICommand ExitApplicationCommand { get; }
        private void AddItem(object obj)
        {
            MessageBox.Show("Add Item");
        }
        private void DeleteItem(object obj)
        {
            PrayerListToDisplay.Remove(SelectedItem);
            SelectedItem = null;
        }
        private void MoveItemToHistory(object obj)
        {
            MessageBox.Show("Move To History");
        }
        private void ToggleHistory(object obj)
        {
            //MessageBox.Show(_historyButtonText);
            if (_displayHistoryList == false)
            {
                HistoryButtonText = "See Current";
                CurrentStatusColour = "LightSalmon";
                CurrentStatusText = "History";
                DisplayHistoryList = true;
            }
            else
            {
                HistoryButtonText = "See History";
                CurrentStatusColour = "LightGreen";
                CurrentStatusText = "Current";
                DisplayHistoryList = false;
            }
        }
        private void ShowCurrent(object obj)
        {
            MessageBox.Show("Show Current Items");
        }
        private void ShowHelp(object obj)
        {
            MessageBox.Show("Show the help page");
        }
        private void NewFile(object obj)
        {
            MessageBox.Show("New File");
        }
        private void OpenFile(object obj)
        {
            MessageBox.Show("Open File");
        }
        private void SaveFileAs(object obj)
        {
            MessageBox.Show("Save File As");
        }
        private void ExportList(object obj)
        {
            MessageBox.Show("Export List");
        }
        private void ExitApplication(object obj)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void ShowHelpAbout(object obj)
        {
            MessageBox.Show("Show Help About");
        }
        private void MoveItemUp(object obj)
        {
            MessageBox.Show("Selected Item Move Up");
        }
        private void MoveItemDown(object obj)
        {
            MessageBox.Show("Selected Item Move Down");
        }
    }
}
