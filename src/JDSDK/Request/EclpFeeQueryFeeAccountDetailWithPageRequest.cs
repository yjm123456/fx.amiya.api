using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpFeeQueryFeeAccountDetailWithPageRequest : JdRequestBase<EclpFeeQueryFeeAccountDetailWithPageResponse>
    {
                                                                                                                                              public  		string
              accountNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              billDayStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              billDayEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.fee.queryFeeAccountDetailWithPage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("accountNo", this.            accountNo
);
                                                                                                        parameters.Add("billDayStart", this.            billDayStart
);
                                                                                                        parameters.Add("billDayEnd", this.            billDayEnd
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

