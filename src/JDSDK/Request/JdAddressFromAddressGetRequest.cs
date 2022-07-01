using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JdAddressFromAddressGetRequest : JdRequestBase<JdAddressFromAddressGetResponse>
    {
                                                                                                                                              public  		string
              userid
 {get; set;}
                                                          
                                                          public  		string
              key
 {get; set;}
                                                          
                                                          public  		string
              provinceId
 {get; set;}
                                                          
                                                          public  		string
              cityId
 {get; set;}
                                                          
                                                          public  		string
              countryId
 {get; set;}
                                                          
                                                          public  		string
              townId
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		string
              shipping
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.JdAddressFromAddress.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("userid", this.            userid
);
                                                                                                        parameters.Add("key", this.            key
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countryId", this.            countryId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("shipping", this.            shipping
);
                                                                            }
    }
}





        
 

