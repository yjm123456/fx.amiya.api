using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpFeeQueryFeeAccountWithPageRequest : JdRequestBase<EclpFeeQueryFeeAccountWithPageResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              accountNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              accountDayStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              accountDayEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.fee.queryFeeAccountWithPage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("accountNo", this.            accountNo
);
                                                                                                        parameters.Add("accountDayStart", this.            accountDayStart
);
                                                                                                        parameters.Add("accountDayEnd", this.            accountDayEnd
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

