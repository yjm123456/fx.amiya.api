using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspRechargeGetRequest : JdRequestBase<DspRechargeGetResponse>
    {
                                                                                                                                                                               public  		Nullable<DateTime>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              pageOffset
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.recharge.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageOffset", this.            pageOffset
);
                                                                                                                            }
    }
}





        
 

