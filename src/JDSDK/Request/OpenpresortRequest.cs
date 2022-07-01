using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OpenpresortRequest : JdRequestBase<OpenpresortResponse>
    {
                                                                                                                                              public  		string
              fullAddress
 {get; set;}
                                                          
                                                          public  		string
              companyCode
 {get; set;}
                                                          
                                                          public  		string
              waybillCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.openpresort";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("fullAddress", this.            fullAddress
);
                                                                                                        parameters.Add("companyCode", this.            companyCode
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                            }
    }
}





        
 

