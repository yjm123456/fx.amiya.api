using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ProductoutstorageRequest : JdRequestBase<ProductoutstorageResponse>
    {
                                                                                                                                                    public  		Nullable<long>
              twoOrderId
 {get; set;}
                                                          
                                                          public  		string
              waybillNumber
 {get; set;}
                                                          
                                                          public  		string
              logisticsCompanies
 {get; set;}
                                                          
                                                          public  		string
              bagCount
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.productoutstorage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("twoOrderId", this.            twoOrderId
);
                                                                                                        parameters.Add("waybillNumber", this.            waybillNumber
);
                                                                                                        parameters.Add("logisticsCompanies", this.            logisticsCompanies
);
                                                                                                        parameters.Add("bagCount", this.            bagCount
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

