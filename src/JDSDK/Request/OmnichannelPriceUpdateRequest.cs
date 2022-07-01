using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelPriceUpdateRequest : JdRequestBase<OmnichannelPriceUpdateResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  venderId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  saleSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  saleSkuName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outerSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outerSkuName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  upc {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outerStoreId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  priceMode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  updateTime {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.omnichannel.price.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("saleSkuId", this.            saleSkuId
);
                                                                                                        parameters.Add("saleSkuName", this.            saleSkuName
);
                                                                                                        parameters.Add("outerSkuId", this.            outerSkuId
);
                                                                                                        parameters.Add("outerSkuName", this.            outerSkuName
);
                                                                                                        parameters.Add("upc", this.            upc
);
                                                                                                        parameters.Add("outerStoreId", this.            outerStoreId
);
                                                                                                        parameters.Add("priceMode", this.            priceMode
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("updateTime", this.            updateTime
);
                                                                                                    }
    }
}





        
 

