using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GetStagepayBusinessExtInfoByCouponCodeRequest : JdRequestBase<GetStagepayBusinessExtInfoByCouponCodeResponse>
    {
                                                                                                                   public  		string
              CouponCode
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.getStagepayBusinessExtInfoByCouponCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("CouponCode", this.            CouponCode
);
                                                    }
    }
}





        
 

