using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelStockChangeUpdateRequest : JdRequestBase<OmnichannelStockChangeUpdateResponse>
    {
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
                get{return "jingdong.omnichannel.stock.change.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
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





        
 

