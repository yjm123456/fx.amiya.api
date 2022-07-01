using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseUnBindingSpuBrokerRequest : JdRequestBase<NewhouseUnBindingSpuBrokerResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  v1 {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              spuId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.unBindingSpuBroker";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                parameters.Add("v1", this.            v1
);
                                                                                                                                parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("spuId", this.            spuId
);
                                                                            }
    }
}





        
 

