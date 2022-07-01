using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddDealAverageRecordRequest : JdRequestBase<ErsFangAddDealAverageRecordResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  dealRecordValue {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  cityCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sourceId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  pSourceId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  externalPlotName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  totalRate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  unitRate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  houseArea {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  houseRoom {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  houseHall {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  finishTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  externalChannelId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  externalChannelName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  externalBrokerId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  externalBrokerName {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ers.fang.addDealAverageRecord";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                        parameters.Add("externalPlotName", this.            externalPlotName
);
                                                                                                        parameters.Add("totalRate", this.            totalRate
);
                                                                                                        parameters.Add("unitRate", this.            unitRate
);
                                                                                                        parameters.Add("houseArea", this.            houseArea
);
                                                                                                        parameters.Add("houseRoom", this.            houseRoom
);
                                                                                                        parameters.Add("houseHall", this.            houseHall
);
                                                                                                        parameters.Add("finishTime", this.            finishTime
);
                                                                                                        parameters.Add("externalChannelId", this.            externalChannelId
);
                                                                                                        parameters.Add("externalChannelName", this.            externalChannelName
);
                                                                                                        parameters.Add("externalBrokerId", this.            externalBrokerId
);
                                                                                                        parameters.Add("externalBrokerName", this.            externalBrokerName
);
                                                                                                    }
    }
}





        
 

