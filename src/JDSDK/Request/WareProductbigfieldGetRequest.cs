using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareProductbigfieldGetRequest : JdRequestBase<WareProductbigfieldGetResponse>
    {
                                                                                  public  		string
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  field {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ware.productbigfield.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                                                                parameters.Add("field", this.            field
);
                                                                            }
    }
}





        
 

