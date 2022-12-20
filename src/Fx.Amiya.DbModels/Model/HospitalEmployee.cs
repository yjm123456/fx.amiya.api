using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class HospitalEmployee
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int HospitalId { get; set; }
        public bool Valid { get; set; }
        public bool IsCreateSubAccount { get; set; }
        public int HospitalPositionId { get; set; }
        public bool IsCustomerService { get; set; }


        public HospitalInfo HospitalInfo { get; set; }
        public HospitalPositionInfo HospitalPositionInfo { get; set; }

        public List<HospitalCheckPhoneRecord> HospitalCheckPhoneRecordList { get; set; }
        public List<SendOrderMessageBoard> SendOrderMessageBoardList { get; set; }
        public List<HospitalBindCustomerService> HospitalBindCustomerServiceList { get; set; }
        public List<HospitalBindCustomerService> CreateByHospitalBindCustomerServiceList { get; set; }
        public List<ReconciliationDocuments> ReconciliationDocumentsList { get; set; }
    }
}
