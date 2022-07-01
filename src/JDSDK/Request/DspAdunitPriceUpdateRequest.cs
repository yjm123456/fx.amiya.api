using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitPriceUpdateRequest : JdRequestBase<DspAdunitPriceUpdateResponse>
    {
                                                                                  public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              inFee
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              outFee
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              adxFee
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adunit.price.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("inFee", this.            inFee
);
                                                                                                        parameters.Add("outFee", this.            outFee
);
                                                                                                        parameters.Add("adxFee", this.            adxFee
);
                                                                                                                                                    }
    }
}





        
 

