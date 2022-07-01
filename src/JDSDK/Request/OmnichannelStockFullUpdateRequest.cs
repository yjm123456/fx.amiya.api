using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelStockFullUpdateRequest : JdRequestBase<OmnichannelStockFullUpdateResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              totalItem
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  stockType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  storeId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  jdSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outerSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  spotStockNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  saleStockNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  produceStockNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  updateTime {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.omnichannel.stock.full.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("totalItem", this.            totalItem
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                                                                                                        parameters.Add("stockType", this.            stockType
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("jdSkuId", this.            jdSkuId
);
                                                                                                        parameters.Add("outerSkuId", this.            outerSkuId
);
                                                                                                        parameters.Add("spotStockNum", this.            spotStockNum
);
                                                                                                        parameters.Add("saleStockNum", this.            saleStockNum
);
                                                                                                        parameters.Add("produceStockNum", this.            produceStockNum
);
                                                                                                        parameters.Add("updateTime", this.            updateTime
);
                                                                                                                            }
    }
}





        
 

