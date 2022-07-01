using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsModifyStockInfoRequest : JdRequestBase<DropshipDpsModifyStockInfoResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  stockNum {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.dropship.dps.modifyStockInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                                            }
    }
}





        
 

