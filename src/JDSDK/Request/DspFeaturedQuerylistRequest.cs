using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspFeaturedQuerylistRequest : JdRequestBase<DspFeaturedQuerylistResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                       public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.featured.querylist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

