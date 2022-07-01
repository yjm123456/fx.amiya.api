using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CustomsEtmsGetCommonWaybillCodeByOrderCodeRequest : JdRequestBase<CustomsEtmsGetCommonWaybillCodeByOrderCodeResponse>
    {
                                                                                                                                                                               public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              mftNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.customs.etms.getCommonWaybillCodeByOrderCode";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("mftNo", this.            mftNo
);
                                                                            }
    }
}





        
 

