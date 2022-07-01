using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EptWarecenterRecommendtempGetRequest : JdRequestBase<EptWarecenterRecommendtempGetResponse>
    {
                                                                                                                   public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ept.warecenter.recommendtemp.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                    }
    }
}





        
 

