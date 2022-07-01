using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpFeeQueryFeeDetailWithPageRequest : JdRequestBase<EclpFeeQueryFeeDetailWithPageResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              billDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.fee.queryFeeDetailWithPage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("billDay", this.            billDay
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

