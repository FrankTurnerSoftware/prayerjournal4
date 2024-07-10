using PrayerJournal.Models;
using System.Collections.ObjectModel;

namespace PrayerJournal.Helpers
{
    public class GenerateTestItems
    {
        public ObservableCollection<PrayerItem> CurrentItems { get; set; }
        public ObservableCollection<PrayerItem> HistoryItems { get; set; }
        public GenerateTestItems()
        {
            CurrentItems = GenerateItems(10);
            HistoryItems = GenerateItems(7, true);
        }

        public ObservableCollection<PrayerItem> GenerateItems(int numberOfRows, bool isHistory = false)
        {
            ObservableCollection<PrayerItem> items = new ObservableCollection<PrayerItem>();

            for (int i = 0; i < numberOfRows; i++)
            {
                PrayerItem item = new PrayerItem
                {
                    Id = i + 1,
                    PrayerHeadline = $"Prayer Headline {i}",
                    PrayerDescription = $"Prayer Description {i}",
                    IsHistory = isHistory,
                    PrayerItemDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };
                items.Add(item);
            }

            return items;
        }
    }
}
