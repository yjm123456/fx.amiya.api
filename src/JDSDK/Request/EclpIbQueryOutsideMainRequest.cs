using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpIbQueryOutsideMainRequest : JdRequestBase<EclpIbQueryOutsideMainResponse>
    {
                                                                                  public  		string
              outsideMainNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.ib.queryOutsideMain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("outsideMainNo", this.            outsideMainNo
);
                                                                                                    }
    }
}





        
 

