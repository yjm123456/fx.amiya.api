using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpAddAdGroupRequest : JdRequestBase<AdsDspRtbTpAddAdGroupResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              feeDecimal
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              recommendAutomatedBiddingType
 {get; set;}
                                                          
                                                          public  		string
              recommendTcpaBid
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.addAdGroup";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("feeDecimal", this.            feeDecimal
);
                                                                                                        parameters.Add("recommendAutomatedBiddingType", this.            recommendAutomatedBiddingType
);
                                                                                                        parameters.Add("recommendTcpaBid", this.            recommendTcpaBid
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

