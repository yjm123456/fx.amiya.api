using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewGetProcessInfoRequest : JdRequestBase<UeOrderNewGetProcessInfoResponse>
    {
                                                                                                                                              public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.getProcessInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                            }
    }
}





        
 

