using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class TrackTheme
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public int TrackTypeId { get; set; }
        public bool Valid { get; set; }

        public TrackType TrackType { get; set; }
        public List<TrackRecord> TrackRecordList { get; set; }
        public List<WaitTrackCustomer> WaitTrackCustomerList { get; set; }

        public List<TrackTypeThemeModel> TrackThemeModel { get; set; }
    }
}
