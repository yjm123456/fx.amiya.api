using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseTrackQueryTrackRequest : JdRequestBase<JwPurchaseTrackQueryTrackResponse>
    {
                                                                                                                                              public  		string
              orderCode
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.track.queryTrack";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderCode", this.            orderCode
);
                                                                                                                                                                            }
    }
}





        
 

