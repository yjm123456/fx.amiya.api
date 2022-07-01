using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bProductGetBigFieldRequest : JdRequestBase<B2bProductGetBigFieldResponse>
    {
                                                                                  public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  fieldKeys {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.b2b.product.getBigField";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                                                parameters.Add("fieldKeys", this.            fieldKeys
);
                                                                                                                            }
    }
}





        
 

