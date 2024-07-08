using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrayerJournal4.Models
{
    public class PrayerItem
    {
        public int Id { get; set; }
        public string PrayerHeadline { get; set; }
        public string PrayerDescription { get; set; }
        public DateTime PrayerItemDate {  get; set; }
        public bool IsHistory { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}

    }
}
