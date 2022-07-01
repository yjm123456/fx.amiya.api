using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdateChannelRequest : JdRequestBase<ErsFangAddOrUpdateChannelResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                          public  		string
              businessType
 {get; set;}
                                                          
                                                          public  		string
              channelName
 {get; set;}
                                                          
                                                          public  		string
              businessLicense
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              companyLogo
 {get; set;}
                                                          
                                                          public  		string
              companyDes
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              purAgentRate
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              sellAgentRate
 {get; set;}
                                                          
                                                          public  		string
              purCagentDes
 {get; set;}
                                                          
                                                          public  		string
              sellCagentDes
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdateChannel";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                        parameters.Add("channelName", this.            channelName
);
                                                                                                        parameters.Add("businessLicense", this.            businessLicense
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("companyLogo", this.            companyLogo
);
                                                                                                        parameters.Add("companyDes", this.            companyDes
);
                                                                                                        parameters.Add("purAgentRate", this.            purAgentRate
);
                                                                                                        parameters.Add("sellAgentRate", this.            sellAgentRate
);
                                                                                                        parameters.Add("purCagentDes", this.            purCagentDes
);
                                                                                                        parameters.Add("sellCagentDes", this.            sellCagentDes
);
                                                                                                                            }
    }
}





        
 

