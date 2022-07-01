using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
   public class AddTrackDto
    {
        public int WaitTrackId { get; set; }
        public string TrackContent { get; set; }
        public string TrackTheme { get; set; }
        public int TrackTypeId { get; set; }
        public int TrackToolId { get; set; }
        public bool Valid { get; set; }
        public string CallRecordId { get; set; }


        public AddWaitTrackCustomerDto AddWaitTrackCustomer { get; set; }
    }
}
