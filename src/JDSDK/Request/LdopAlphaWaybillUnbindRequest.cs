using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaWaybillUnbindRequest : JdRequestBase<LdopAlphaWaybillUnbindResponse>
    {
                                                                                                                                              public  		string
              platformOrderNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              providerId
 {get; set;}
                                                          
                                                          public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  waybillCodeList {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.ldop.alpha.waybill.unbind";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("platformOrderNo", this.            platformOrderNo
);
                                                                                                        parameters.Add("providerId", this.            providerId
);
                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("operatorTime", this.            operatorTime
);
                                                                                                                                                parameters.Add("waybillCodeList", this.            waybillCodeList
);
                                                                                                    }
    }
}





        
 

