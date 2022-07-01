using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopTaurusQueryRefundBillChargeListByConditionRequest : JdRequestBase<PopTaurusQueryRefundBillChargeListByConditionResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              businessBeginTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dateType
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              settlementStatus
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  orderId {get; set; }
                                                                                                                                                                                                public  		Nullable<DateTime>
              businessEndTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.taurus.queryRefundBillChargeListByCondition";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("businessBeginTime", this.            businessBeginTime
);
                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("settlementStatus", this.            settlementStatus
);
                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                                                parameters.Add("businessEndTime", this.            businessEndTime
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                            }
    }
}





        
 

