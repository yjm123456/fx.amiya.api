using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdwordsReadFindAdWordsByWareIdRequest : JdRequestBase<AdwordsReadFindAdWordsByWareIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.adwords.read.findAdWordsByWareId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                    }
    }
}





        
 

