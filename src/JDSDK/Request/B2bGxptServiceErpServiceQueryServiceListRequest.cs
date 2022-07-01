using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bGxptServiceErpServiceQueryServiceListRequest : JdRequestBase<B2bGxptServiceErpServiceQueryServiceListResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              applyStartDate
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              purchaseId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyEndDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitEndDate
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceStatus
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitStartDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              saleServiceType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startModified
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endModified
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.gxpt.serviceErpService.queryServiceList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("applyStartDate", this.            applyStartDate
);
                                                                                                        parameters.Add("purchaseId", this.            purchaseId
);
                                                                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("applyEndDate", this.            applyEndDate
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("submitEndDate", this.            submitEndDate
);
                                                                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("serviceStatus", this.            serviceStatus
);
                                                                                                        parameters.Add("submitStartDate", this.            submitStartDate
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("saleServiceType", this.            saleServiceType
);
                                                                                                        parameters.Add("startModified", this.            startModified
);
                                                                                                        parameters.Add("endModified", this.            endModified
);
                                                                            }
    }
}





        
 

