using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddCityRateRequest : JdRequestBase<ErsFangAddCityRateResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		string
              averageRate
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              linkRelativeRate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              rateDate
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addCityRate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("averageRate", this.            averageRate
);
                                                                                                        parameters.Add("linkRelativeRate", this.            linkRelativeRate
);
                                                                                                        parameters.Add("rateDate", this.            rateDate
);
                                                                                                                            }
    }
}





        
 

