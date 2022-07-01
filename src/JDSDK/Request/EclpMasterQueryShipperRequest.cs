using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQueryShipperRequest : JdRequestBase<EclpMasterQueryShipperResponse>
    {
                                                                                  public  		string
              shipperNos
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.master.queryShipper";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("shipperNos", this.            shipperNos
);
                                                                                                    }
    }
}





        
 

