using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitAdgroupDeleteRequest : JdRequestBase<DspAdunitAdgroupDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  adGroupId {get; set; }
                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.dsp.adunit.adgroup.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                    }
    }
}





        
 

