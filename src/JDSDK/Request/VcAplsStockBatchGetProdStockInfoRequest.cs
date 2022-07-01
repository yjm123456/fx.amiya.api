using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcAplsStockBatchGetProdStockInfoRequest : JdRequestBase<VcAplsStockBatchGetProdStockInfoResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                                                      public  		string
              skuList
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.vc.apls.stock.batchGetProdStockInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("skuList", this.            skuList
);
                                                                            }
    }
}





        
 

