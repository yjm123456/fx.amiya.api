using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitAdgroupAddRequest : JdRequestBase<DspAdkcunitAdgroupAddResponse>
    {
                                                                                                                                              public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		string
              newAreaId
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
                get{return "jingdong.dsp.adkcunit.adgroup.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("newAreaId", this.            newAreaId
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





        
 

