using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdateDescribeRequest : JdRequestBase<ErsFangAddOrUpdateDescribeResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelId
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              publishDate
 {get; set;}
                                                          
                                                          public  		string
              sourceUrl
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pSourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdateDescribe";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                        parameters.Add("publishDate", this.            publishDate
);
                                                                                                        parameters.Add("sourceUrl", this.            sourceUrl
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                                            }
    }
}





        
 

