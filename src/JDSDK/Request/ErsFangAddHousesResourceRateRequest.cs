using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddHousesResourceRateRequest : JdRequestBase<ErsFangAddHousesResourceRateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelId
 {get; set;}
                                                          
                                                          public  		string
              totalPrice
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pSourceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              rateDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ers.fang.addHousesResourceRate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                                                        parameters.Add("rateDate", this.            rateDate
);
                                                                            }
    }
}





        
 

