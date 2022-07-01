using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpRtwTransportRtwRequest : JdRequestBase<EclpRtwTransportRtwResponse>
    {
                                                                                                                                              public  		string
              eclpSoNo
 {get; set;}
                                                          
                                                          public  		string
              eclpRtwNo
 {get; set;}
                                                          
                                                          public  		string
              isvRtwNum
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              reson
 {get; set;}
                                                          
                                                          public  		string
              orderInType
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.rtw.transportRtw";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("eclpSoNo", this.            eclpSoNo
);
                                                                                                        parameters.Add("eclpRtwNo", this.            eclpRtwNo
);
                                                                                                        parameters.Add("isvRtwNum", this.            isvRtwNum
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("reson", this.            reson
);
                                                                                                        parameters.Add("orderInType", this.            orderInType
);
                                                                                                                            }
    }
}





        
 

