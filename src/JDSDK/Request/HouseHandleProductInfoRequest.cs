using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseHandleProductInfoRequest : JdRequestBase<HouseHandleProductInfoResponse>
    {
                                                                                  public  		string
              productInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.house.handleProductInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("productInfo", this.            productInfo
);
                                                                                                    }
    }
}





        
 

