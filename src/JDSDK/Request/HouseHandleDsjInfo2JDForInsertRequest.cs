using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseHandleDsjInfo2JDForInsertRequest : JdRequestBase<HouseHandleDsjInfo2JDForInsertResponse>
    {
                                                                                  public  		string
              productInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.house.handleDsjInfo2JDForInsert";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("productInfo", this.            productInfo
);
                                                                                                    }
    }
}





        
 

