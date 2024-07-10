using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using PrayerJournal.Models;

namespace PrayerJournal.ViewModels
{
    public partial class MainViewModel
    {
        private const string LastFileKey = "LastOpenedFile";
        // Menu Bar Commands
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand MoveItemToHistoryCommand { get; }
        public ICommand HistoryToggleCommand { get; }

        // File Menu Commands
        public ICommand OpenFileCommand { get; }
        public ICommand NewFileCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveFileAsCommand { get; }
        public ICommand ExitApplicationCommand { get; }
        private void AddItem(object obj)
        {
            SelectedItem = new PrayerItem
            {
                PrayerHeadline = "<New Item>",
                PrayerItemDate = DateTime.Now,
                IsHistory = DisplayHistoryList,
                CreatedDate = DateTime.Now
            };
            PrayerListToDisplay.Add(SelectedItem);
        }
        private void DeleteItem(object obj)
        {
            int selectedindex = SelectedIndex;
            PrayerListToDisplay.Remove(SelectedItem);
            SelectedItem = null;

            SelectedIndex = selectedindex - 1;

        }
        private void MoveItemToAndFromHistory(object obj)
        {
            if (DisplayHistoryList == true)
            {
                SelectedItem.IsHistory = false;
                CurrentItems.Add(SelectedItem);
                HistoryItems.Remove(SelectedItem);
                PrayerListToDisplay.Remove(SelectedItem);
                SelectedItem = null;
            }
            else if (DisplayHistoryList == false)
            {
                SelectedItem.IsHistory = true;
                HistoryItems.Add(SelectedItem);
                CurrentItems.Remove(SelectedItem);
                PrayerListToDisplay.Remove(SelectedItem);
                SelectedItem = null;
            }
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

        private void ShowHelp(object obj)
        {
            MessageBox.Show("Show the help page");
        }

        private void LoadLastOpenedFile()
        {
            string lastFile = ConfigurationManager.AppSettings[LastFileKey];

            if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
            {
                // Ideally you wouldn't duplicate the code for OpenFile function
                FileModel fileModel = new FileModel(CurrentItems, HistoryItems);

                string jsonContent = File.ReadAllText(lastFile);
                fileModel.OpenFile(jsonContent);
                Filename = fileModel.FilePath;
                CurrentItems = fileModel.CurrentItems;
                HistoryItems = fileModel.HistoryItems;
            }
        }
        private void NewFile(object obj)
        {
            CurrentItems.Clear();
            HistoryItems.Clear();
            PrayerListToDisplay.Clear();
            Filename = null;
        }
        private void OpenFile(object obj)
        {
            FileModel fileModel = new FileModel(CurrentItems, HistoryItems);
            string message = fileModel.OpenFileWithDialog();

            Filename = fileModel.FilePath;
            CurrentItems = fileModel.CurrentItems;
            HistoryItems = fileModel.HistoryItems;

            SaveLastOpenedFile(Filename);
            MessageBox.Show(message);
        }
        private void SaveFile(object obj)
        {
            if (Filename == null)
            {
                SaveFileAs(obj);
            }
            else
            {
                FileModel fileModel = new FileModel(CurrentItems, HistoryItems);
                string saveresponse = fileModel.SaveAllItems(Filename);
                MessageBox.Show(saveresponse);
            }

            SaveLastOpenedFile(Filename);
        }
        private void SaveFileAs(object obj)
        {
            // Get the new filename
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Prayer List File (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                Filename = filename;
                // Then save it
                SaveFile(obj);
            }
            SaveLastOpenedFile(Filename);
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

        private void SaveLastOpenedFile(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[LastFileKey].Value = filePath;
            config.AppSettings.Settings["StartFilePath"].Value = directoryPath;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
