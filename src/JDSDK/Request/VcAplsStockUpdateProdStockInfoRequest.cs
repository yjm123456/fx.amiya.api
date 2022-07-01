using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcAplsStockUpdateProdStockInfoRequest : JdRequestBase<VcAplsStockUpdateProdStockInfoResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              companyId
 {get; set;}
                                                          
                                                          public  		string
              stockRfId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		Nullable<long>
  skuid {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		Nullable<int>
  stockNum {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.vc.apls.stock.updateProdStockInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("companyId", this.            companyId
);
                                                                                                        parameters.Add("stockRfId", this.            stockRfId
);
                                                                                                                                                                                        parameters.Add("skuid", this.            skuid
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                                            }
    }
}





        
 

