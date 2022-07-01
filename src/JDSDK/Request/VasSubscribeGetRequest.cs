using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VasSubscribeGetRequest : JdRequestBase<VasSubscribeGetResponse>
    {
                                                                                  public  		string
                                                                                      userName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      itemCode
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.vas.subscribe.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("user_name", this.                                                                                    userName
);
                                                                                                        parameters.Add("item_code", this.                                                                                    itemCode
);
                                                                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                    }
    }
}





        
 

