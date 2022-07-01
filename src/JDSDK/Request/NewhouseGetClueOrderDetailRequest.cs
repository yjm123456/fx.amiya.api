using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseGetClueOrderDetailRequest : JdRequestBase<NewhouseGetClueOrderDetailResponse>
    {
                                                                                                                                              public  		string
              venderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clueId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.getClueOrderDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("clueId", this.            clueId
);
                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                            }
    }
}





        
 

