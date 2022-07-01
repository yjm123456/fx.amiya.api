using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NbhouseRentSpuPublishServiceRequest : JdRequestBase<NbhouseRentSpuPublishServiceResponse>
    {
                                                                                                                                              public  		Nullable<long>
              staffId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              plotId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              spuId
 {get; set;}
                                                          
                                                          public  		string
              spuName
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		string
              skuName
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.nbhouse.rent.spu.publishService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("staffId", this.            staffId
);
                                                                                                        parameters.Add("plotId", this.            plotId
);
                                                                                                        parameters.Add("spuId", this.            spuId
);
                                                                                                        parameters.Add("spuName", this.            spuName
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("skuName", this.            skuName
);
                                                                                                                            }
    }
}





        
 

