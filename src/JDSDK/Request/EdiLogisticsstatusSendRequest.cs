using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiLogisticsstatusSendRequest : JdRequestBase<EdiLogisticsstatusSendResponse>
    {
                                                                                                                                              public  		string
              vendorName
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  orderType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  asnCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  purchaseOrderCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  supposedArrivedDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventLocation {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventNameCn {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eventNameEn {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  nextEventCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  nextEventTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  nextEventLocation {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  nextEventNameCn {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  nextEventNameEn {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.logisticsstatus.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                                                                                                                                parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("asnCode", this.            asnCode
);
                                                                                                        parameters.Add("purchaseOrderCode", this.            purchaseOrderCode
);
                                                                                                        parameters.Add("supposedArrivedDate", this.            supposedArrivedDate
);
                                                                                                        parameters.Add("eventCode", this.            eventCode
);
                                                                                                        parameters.Add("eventTime", this.            eventTime
);
                                                                                                        parameters.Add("eventLocation", this.            eventLocation
);
                                                                                                        parameters.Add("eventNameCn", this.            eventNameCn
);
                                                                                                        parameters.Add("eventNameEn", this.            eventNameEn
);
                                                                                                        parameters.Add("nextEventCode", this.            nextEventCode
);
                                                                                                        parameters.Add("nextEventTime", this.            nextEventTime
);
                                                                                                        parameters.Add("nextEventLocation", this.            nextEventLocation
);
                                                                                                        parameters.Add("nextEventNameCn", this.            nextEventNameCn
);
                                                                                                        parameters.Add("nextEventNameEn", this.            nextEventNameEn
);
                                                                                                    }
    }
}





        
 

