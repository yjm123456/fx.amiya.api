using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangSaveTradingAreaRequest : JdRequestBase<ErsFangSaveTradingAreaResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                                           public  		string
              tradingAreaName
 {get; set;}
                                                          
                                                          public  		string
              addressLat
 {get; set;}
                                                          
                                                          public  		string
              addressLon
 {get; set;}
                                                          
                                                          public  		string
              latLonType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ers.fang.saveTradingArea";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                                                        parameters.Add("tradingAreaName", this.            tradingAreaName
);
                                                                                                        parameters.Add("addressLat", this.            addressLat
);
                                                                                                        parameters.Add("addressLon", this.            addressLon
);
                                                                                                        parameters.Add("latLonType", this.            latLonType
);
                                                                            }
    }
}





        
 

