using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareWriteUpdateWareStatusByTimerRequest : JdRequestBase<WareWriteUpdateWareStatusByTimerResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              upTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              downTime
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ware.write.updateWareStatusByTimer";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("upTime", this.            upTime
);
                                                                                                        parameters.Add("downTime", this.            downTime
);
                                                    }
    }
}





        
 

