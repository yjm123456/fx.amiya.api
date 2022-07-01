using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheGroupUpdatefeeRequest : JdRequestBase<AdsDspRtbKuaicheGroupUpdatefeeResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              mobilePriceCoef
 {get; set;}
                                                          
                                                          public  		string
              inSearchFee
 {get; set;}
                                                          
                                                          public  		string
              recommendFee
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.group.updatefee";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("mobilePriceCoef", this.            mobilePriceCoef
);
                                                                                                        parameters.Add("inSearchFee", this.            inSearchFee
);
                                                                                                        parameters.Add("recommendFee", this.            recommendFee
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

