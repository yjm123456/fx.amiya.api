using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bGxptProductServiceQueryProductStockRequest : JdRequestBase<B2bGxptProductServiceQueryProductStockResponse>
    {
                                                                                  public  		Nullable<long>
              venderId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  skuSet {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.b2b.gxpt.ProductService.queryProductStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("venderId", this.            venderId
);
                                                                                                                                                parameters.Add("skuSet", this.            skuSet
);
                                                                                                                            }
    }
}





        
 

