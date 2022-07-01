using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicStockImportRequest : JdRequestBase<OmnicStockImportResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                              		public  		string
  jdSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  stockType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outerSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  upc {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  updateTime {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  spotStockNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  storeId {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.omnic.stock.import";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                                                        parameters.Add("jdSkuId", this.            jdSkuId
);
                                                                                                        parameters.Add("stockType", this.            stockType
);
                                                                                                        parameters.Add("outerSkuId", this.            outerSkuId
);
                                                                                                        parameters.Add("upc", this.            upc
);
                                                                                                        parameters.Add("updateTime", this.            updateTime
);
                                                                                                        parameters.Add("spotStockNum", this.            spotStockNum
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                            }
    }
}





        
 

