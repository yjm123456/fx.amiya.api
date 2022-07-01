using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsPartitionStockMaintainRequest : JdRequestBase<DropshipDpsPartitionStockMaintainResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  stockNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  storeId {get; set; }
                                                                                                                                                                                                                                 public  		string
              rfId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dropship.dps.partitionStock.maintain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                                                                        parameters.Add("rfId", this.            rfId
);
                                                    }
    }
}





        
 

