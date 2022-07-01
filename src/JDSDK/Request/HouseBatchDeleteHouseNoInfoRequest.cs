using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseBatchDeleteHouseNoInfoRequest : JdRequestBase<HouseBatchDeleteHouseNoInfoResponse>
    {
                                                                                  public  		string
              houseNoInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.house.batchDeleteHouseNoInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("houseNoInfo", this.            houseNoInfo
);
                                                                                                    }
    }
}





        
 

