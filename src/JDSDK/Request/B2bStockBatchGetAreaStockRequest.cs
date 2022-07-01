using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bStockBatchGetAreaStockRequest : JdRequestBase<B2bStockBatchGetAreaStockResponse>
    {
                                                                                  public  		string
              appName
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                            public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.b2b.stock.batchGetAreaStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("appName", this.            appName
);
                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                                                                                                                parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                                            }
    }
}





        
 

