using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpAfsQueryServiceItemInfoByServiceNoRequest : JdRequestBase<EclpAfsQueryServiceItemInfoByServiceNoResponse>
    {
                                                                                  public  		string
              servicesNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.afs.queryServiceItemInfoByServiceNo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("servicesNo", this.            servicesNo
);
                                                                                                    }
    }
}





        
 

