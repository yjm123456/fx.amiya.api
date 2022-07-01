using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseChannelBrokersaveRequest : JdRequestBase<NewhouseChannelBrokersaveResponse>
    {
                                                                                                                                              public  		Nullable<int>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                                          public  		string
              brokerName
 {get; set;}
                                                          
                                                          public  		string
              brokerPhone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              brokerGender
 {get; set;}
                                                          
                                                          public  		string
              brokerDepartment
 {get; set;}
                                                          
                                                          public  		string
              brokerImg
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              brokerRole
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              imid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              brokerType
 {get; set;}
                                                          
                                                          public  		string
              businessRecord
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.channel.brokersave";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("brokerName", this.            brokerName
);
                                                                                                        parameters.Add("brokerPhone", this.            brokerPhone
);
                                                                                                        parameters.Add("brokerGender", this.            brokerGender
);
                                                                                                        parameters.Add("brokerDepartment", this.            brokerDepartment
);
                                                                                                        parameters.Add("brokerImg", this.            brokerImg
);
                                                                                                        parameters.Add("brokerRole", this.            brokerRole
);
                                                                                                        parameters.Add("imid", this.            imid
);
                                                                                                        parameters.Add("brokerType", this.            brokerType
);
                                                                                                        parameters.Add("businessRecord", this.            businessRecord
);
                                                                            }
    }
}





        
 

