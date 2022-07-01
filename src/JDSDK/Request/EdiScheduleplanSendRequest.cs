using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiScheduleplanSendRequest : JdRequestBase<EdiScheduleplanSendResponse>
    {
                                                                                                                                              public  		string
              schedulePlanCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                              		public  		string
  jdSku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  vendorProductId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  schedulePlanTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.scheduleplan.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("schedulePlanCode", this.            schedulePlanCode
);
                                                                                                                                                                                                                                                                parameters.Add("jdSku", this.            jdSku
);
                                                                                                        parameters.Add("vendorProductId", this.            vendorProductId
);
                                                                                                        parameters.Add("schedulePlanTime", this.            schedulePlanTime
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                    }
    }
}





        
 

