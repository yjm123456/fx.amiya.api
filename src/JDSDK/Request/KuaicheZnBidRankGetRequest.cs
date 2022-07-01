using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnBidRankGetRequest : JdRequestBase<KuaicheZnBidRankGetResponse>
    {
                                                                                                                   public  		string
                                                                                      planJson
 {get; set;}
                                                                                                                                  
                                                                                                                      public  		Nullable<long>
              cid
 {get; set;}
                                                          
                                                          public  		Nullable<long>
                                                                                      kwgId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      planDate
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.bid.rank.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("plan_json", this.                                                                                    planJson
);
                                                                                                                                                parameters.Add("cid", this.            cid
);
                                                                                                        parameters.Add("kwg_id", this.                                                                                    kwgId
);
                                                                                                        parameters.Add("plan_date", this.                                                                                    planDate
);
                                                                            }
    }
}





        
 

