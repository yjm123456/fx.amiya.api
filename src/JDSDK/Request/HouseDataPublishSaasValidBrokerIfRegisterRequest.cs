using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseDataPublishSaasValidBrokerIfRegisterRequest : JdRequestBase<HouseDataPublishSaasValidBrokerIfRegisterResponse>
    {
                                                                                                                                              public  		string
              phone
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.house.data.publish.saas.validBrokerIfRegister";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                                            }
    }
}





        
 

