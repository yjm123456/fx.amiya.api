using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitDmpGetcrowdlistRequest : JdRequestBase<DspAdunitDmpGetcrowdlistResponse>
    {
                                                                                                                   public  		string
              crowdName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adunit.dmp.getcrowdlist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("crowdName", this.            crowdName
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                    }
    }
}





        
 

