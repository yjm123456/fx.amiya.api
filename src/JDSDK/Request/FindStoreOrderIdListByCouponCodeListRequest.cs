using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FindStoreOrderIdListByCouponCodeListRequest : JdRequestBase<FindStoreOrderIdListByCouponCodeListResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  couponCode {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.findStoreOrderIdListByCouponCodeList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("couponCode", this.            couponCode
);
                                                                            }
    }
}





        
 

