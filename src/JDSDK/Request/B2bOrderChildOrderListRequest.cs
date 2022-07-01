using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bOrderChildOrderListRequest : JdRequestBase<B2bOrderChildOrderListResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  orderId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  customKeys {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.b2b.order.childOrderList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                                                                                                                                                                parameters.Add("customKeys", this.            customKeys
);
                                                                            }
    }
}





        
 

