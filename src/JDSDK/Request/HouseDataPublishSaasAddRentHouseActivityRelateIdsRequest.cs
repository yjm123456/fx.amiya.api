using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseDataPublishSaasAddRentHouseActivityRelateIdsRequest : JdRequestBase<HouseDataPublishSaasAddRentHouseActivityRelateIdsResponse>
    {
                                                                                  public  		string
              relateInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.house.data.publish.saas.addRentHouseActivityRelateIds";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("relateInfo", this.            relateInfo
);
                                                                                                    }
    }
}





        
 

