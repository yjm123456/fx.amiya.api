using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class TrackTool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }

        public List<TrackRecord> TrackRecordList { get; set; }
    }
}
