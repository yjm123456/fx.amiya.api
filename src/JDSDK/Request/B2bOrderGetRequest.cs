using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bOrderGetRequest : JdRequestBase<B2bOrderGetResponse>
    {
                                                                                                                                              public  		Nullable<long>
              jdOrderId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  customKeys {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.b2b.order.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("jdOrderId", this.            jdOrderId
);
                                                                                                                                                                                                                        parameters.Add("customKeys", this.            customKeys
);
                                                                            }
    }
}





        
 

