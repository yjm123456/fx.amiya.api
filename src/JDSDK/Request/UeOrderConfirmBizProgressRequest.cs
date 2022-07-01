using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderConfirmBizProgressRequest : JdRequestBase<UeOrderConfirmBizProgressResponse>
    {
                                                                                                                                              public  		string
              appId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  orderNos {get; set; }
                                                                                                                                                                                                public  		string
              type
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.confirmBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                                                                parameters.Add("orderNos", this.            orderNos
);
                                                                                                                                parameters.Add("type", this.            type
);
                                                                            }
    }
}





        
 

