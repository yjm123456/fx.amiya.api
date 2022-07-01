using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockRefundSearchRequest : JdRequestBase<LasSpareZerostockRefundSearchResponse>
    {
                                                                                  public  		string
                                                                                      outNo
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.refund.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("out_no", this.                                                                                    outNo
);
                                                    }
    }
}





        
 

