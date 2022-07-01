using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WjBrandQueryStoreDataRequest : JdRequestBase<WjBrandQueryStoreDataResponse>
    {
                                                                                                                                              public  		string
              token
 {get; set;}
                                                          
                                                          public  		string
              brandId
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              date
 {get; set;}
                                                          
                                                          public  		string
              startPage
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.wjBrand.queryStoreData";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("token", this.            token
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("date", this.            date
);
                                                                                                        parameters.Add("startPage", this.            startPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

