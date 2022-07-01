using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordRankSaveRequest : JdRequestBase<DspAdkckeywordRankSaveResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              searchPromoteRankEnable
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              searchPromoteRankType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              searchPromoteRankCoef
 {get; set;}
                                                          
                                                                                      public  		string
              ids
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.rank.save";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("searchPromoteRankEnable", this.            searchPromoteRankEnable
);
                                                                                                        parameters.Add("searchPromoteRankType", this.            searchPromoteRankType
);
                                                                                                        parameters.Add("searchPromoteRankCoef", this.            searchPromoteRankCoef
);
                                                                                                        parameters.Add("ids", this.            ids
);
                                                                            }
    }
}





        
 

