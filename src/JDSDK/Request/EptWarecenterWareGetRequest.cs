using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EptWarecenterWareGetRequest : JdRequestBase<EptWarecenterWareGetResponse>
    {
                                                                                  public  		string
              wareId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ept.warecenter.ware.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                    }
    }
}





        
 

