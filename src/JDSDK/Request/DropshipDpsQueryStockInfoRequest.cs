using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsQueryStockInfoRequest : JdRequestBase<DropshipDpsQueryStockInfoResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  sku {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.dropship.dps.queryStockInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                            }
    }
}





        
 

