using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class TrackType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
        public bool HasModel { get; set; }
        public bool IsOldCustomer { get; set; }
        public List<TrackRecord> TrackRecordList { get; set; }
        public List<TrackTheme> TrackThemeList { get; set; }
        public List<WaitTrackCustomer> WaitTrackCustomerList { get; set; }

        public List<TrackTypeThemeModel> TrackTypeModel { get; set; }

    }
}
