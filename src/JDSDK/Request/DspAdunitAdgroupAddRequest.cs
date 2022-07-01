using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitAdgroupAddRequest : JdRequestBase<DspAdunitAdgroupAddResponse>
    {
                                                                                                                                              public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                                                           public  		string
              position
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              inFee
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              outFee
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              adOptimize
 {get; set;}
                                                          
                                                                                                                                                             public  		Nullable<int>
              adDevice
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adunit.adgroup.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                                                                        parameters.Add("position", this.            position
);
                                                                                                        parameters.Add("inFee", this.            inFee
);
                                                                                                        parameters.Add("outFee", this.            outFee
);
                                                                                                        parameters.Add("adOptimize", this.            adOptimize
);
                                                                                                                                                                                                                                parameters.Add("adDevice", this.            adDevice
);
                                                                                                    }
    }
}





        
 

