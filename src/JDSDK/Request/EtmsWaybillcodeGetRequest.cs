using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EtmsWaybillcodeGetRequest : JdRequestBase<EtmsWaybillcodeGetResponse>
    {
                                                                                                                                                                                                                public  		string
              preNum
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.etms.waybillcode.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("preNum", this.            preNum
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                            }
    }
}





        
 

