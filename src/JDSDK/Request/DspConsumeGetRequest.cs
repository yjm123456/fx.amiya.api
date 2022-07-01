using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspConsumeGetRequest : JdRequestBase<DspConsumeGetResponse>
    {
                                                                                                                                                                               public  		Nullable<DateTime>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              pageIndex
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.consume.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                            }
    }
}





        
 

