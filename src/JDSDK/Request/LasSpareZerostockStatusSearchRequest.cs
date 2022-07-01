using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockStatusSearchRequest : JdRequestBase<LasSpareZerostockStatusSearchResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              token
 {get; set;}
                                                          
                                                          public  		string
              serviceNo
 {get; set;}
                                                          
                                                          public  		string
              afsServiceTaskNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              requestTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.status.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("token", this.            token
);
                                                                                                        parameters.Add("serviceNo", this.            serviceNo
);
                                                                                                        parameters.Add("afsServiceTaskNo", this.            afsServiceTaskNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("requestTime", this.            requestTime
);
                                                                            }
    }
}





        
 

