using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddtTradingAreaRateRequest : JdRequestBase<ErsFangAddtTradingAreaRateResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pSourceId
 {get; set;}
                                                          
                                                          public  		string
              tradingAreaRate
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              linkRelativeRate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              rateDate
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addtTradingAreaRate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                        parameters.Add("tradingAreaRate", this.            tradingAreaRate
);
                                                                                                        parameters.Add("linkRelativeRate", this.            linkRelativeRate
);
                                                                                                        parameters.Add("rateDate", this.            rateDate
);
                                                                                                                            }
    }
}





        
 

