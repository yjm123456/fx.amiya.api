using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HousedataGenerateHouseNewsRequest : JdRequestBase<HousedataGenerateHouseNewsResponse>
    {
                                                                                  public  		string
              articleParam
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.housedata.generateHouseNews";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("articleParam", this.            articleParam
);
                                                                                                                                                    }
    }
}





        
 

