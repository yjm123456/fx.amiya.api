using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fx.Amiya.Call.Api.Vo.CallRecord
{
    [Serializable]
    public class CallRecordVo: FxMongoBaseModel
    {
        public CallRecordVo()
        {

        }
        public ObjectId _id { get; set; }
        public string UseLineNumber { get; set; }
        public string HotLineNumber { get; set; }
        public int OutChannelID { get; set; }
        public int? InChannelID { get; set; }
        public string InChannelCode { get; set; }
        private string _callNumber;
        public string CallNumber { get {
                return _callNumber;
            } set {
                _callNumber = ProcessHideString(value);
            } }

        public DateTime Date { get; set; }
        public string MacAddress { get; set; }
        public string DeptID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ClientToken { get; set; }

        public CallVoiceDataVo Voice { get; set; }
        public string CallType { get; set; }
        public bool IsConnect { get; set; }
        // public TimeSpan VoiceTime { get; set; }
        public string VoiceTime { get; set; }

        private string ProcessHideString(string str)
        {
            return Regex.Replace(str, "(\\d{3})\\d{4}(\\d{4})", "$1****$2");
        }
    }
}
