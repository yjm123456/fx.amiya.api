using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ProductweighRequest : JdRequestBase<ProductweighResponse>
    {
                                                                                                                                                    public  		Nullable<long>
              oneOrderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              actualWeight
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              billingWeight
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              jysSkuLength
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              jysSkuWidth
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              jysSkuHeight
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.productweigh";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("oneOrderId", this.            oneOrderId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("actualWeight", this.            actualWeight
);
                                                                                                        parameters.Add("billingWeight", this.            billingWeight
);
                                                                                                        parameters.Add("jysSkuLength", this.            jysSkuLength
);
                                                                                                        parameters.Add("jysSkuWidth", this.            jysSkuWidth
);
                                                                                                        parameters.Add("jysSkuHeight", this.            jysSkuHeight
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

