using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AgingtemplGetRequest : JdRequestBase<AgingtemplGetResponse>
    {
                                                                                                                                              public  		string
              source
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.agingtempl.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                            }
    }
}





        
 

