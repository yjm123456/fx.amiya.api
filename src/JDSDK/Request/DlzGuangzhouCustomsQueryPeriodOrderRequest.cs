using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DlzGuangzhouCustomsQueryPeriodOrderRequest : JdRequestBase<DlzGuangzhouCustomsQueryPeriodOrderResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dlz.guangzhou.customs.queryPeriodOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                            }
    }
}





        
 

