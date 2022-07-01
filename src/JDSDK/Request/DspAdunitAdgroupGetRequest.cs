using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitAdgroupGetRequest : JdRequestBase<DspAdunitAdgroupGetResponse>
    {
                                                                                  public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adunit.adgroup.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("id", this.            id
);
                                                                                                                                                    }
    }
}





        
 

