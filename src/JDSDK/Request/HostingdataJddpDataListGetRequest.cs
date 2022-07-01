using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HostingdataJddpDataListGetRequest : JdRequestBase<HostingdataJddpDataListGetResponse>
    {
                                                                                                                                              public  		string
              sqlId
 {get; set;}
                                                          
                                                          public  		string
              parameter
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.hostingdata.jddp.data.list.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sqlId", this.            sqlId
);
                                                                                                        parameters.Add("parameter", this.            parameter
);
                                                                                                                                                                                                                            }
    }
}





        
 

