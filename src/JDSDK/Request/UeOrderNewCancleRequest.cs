using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewCancleRequest : JdRequestBase<UeOrderNewCancleResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              cancleReason
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cancleType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.cancle";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("cancleReason", this.            cancleReason
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("cancleType", this.            cancleType
);
                                                                            }
    }
}





        
 

