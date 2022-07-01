using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitShoppriceUpdateRequest : JdRequestBase<DspAdkcunitShoppriceUpdateResponse>
    {
                                                                                  public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              feeStr
 {get; set;}
                                                          
                                                          public  		string
              inSearchFeeStr
 {get; set;}
                                                          
                                                                                                                            public  	    Nullable<double>
              mobilePriceCoef
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.shopprice.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("feeStr", this.            feeStr
);
                                                                                                        parameters.Add("inSearchFeeStr", this.            inSearchFeeStr
);
                                                                                                                                                                                                        parameters.Add("mobilePriceCoef", this.            mobilePriceCoef
);
                                                    }
    }
}





        
 

