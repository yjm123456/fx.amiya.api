using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Call.Api.Vo.CallRecord
{
    [Serializable]
    public class CallVoiceDataVo: GridFSData
    {
        public ObjectId FileKey
        {
            get { return base.Key; }
            set { base.Key = value; }
        }
        public byte[] VoiceData
        {
            get
            {
                return base.Data;
            }
            set
            {
                base.Data = VoiceData;
            }
        }
    }
}
