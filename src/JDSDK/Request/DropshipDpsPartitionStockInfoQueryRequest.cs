using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsPartitionStockInfoQueryRequest : JdRequestBase<DropshipDpsPartitionStockInfoQueryResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  storeId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  page {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  pageSize {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.dropship.dps.partitionStockInfo.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                    }
    }
}





        
 

