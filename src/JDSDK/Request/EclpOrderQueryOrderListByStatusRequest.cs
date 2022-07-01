using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderQueryOrderListByStatusRequest : JdRequestBase<EclpOrderQueryOrderListByStatusResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              soStatus
 {get; set;}
                                                          
                                                          public  		string
              pageNo
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              billType
 {get; set;}
                                                          
                                                          public  		string
              soNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.order.queryOrderListByStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("soStatus", this.            soStatus
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("billType", this.            billType
);
                                                                                                        parameters.Add("soNo", this.            soNo
);
                                                                            }
    }
}





        
 

