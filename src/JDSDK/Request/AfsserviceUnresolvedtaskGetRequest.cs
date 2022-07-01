using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AfsserviceUnresolvedtaskGetRequest : JdRequestBase<AfsserviceUnresolvedtaskGetResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              afsServiceId
 {get; set;}
                                                          
                                                          public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              afsApplyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              afsApplyTimeEnd
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.afsservice.unresolvedtask.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("afsServiceId", this.            afsServiceId
);
                                                                                                        parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("afsApplyTimeBegin", this.            afsApplyTimeBegin
);
                                                                                                        parameters.Add("afsApplyTimeEnd", this.            afsApplyTimeEnd
);
                                                                            }
    }
}





        
 

