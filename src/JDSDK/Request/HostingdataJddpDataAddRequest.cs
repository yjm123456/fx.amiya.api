using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HostingdataJddpDataAddRequest : JdRequestBase<HostingdataJddpDataAddResponse>
    {
                                                                                                                                              public  		string
              tableName
 {get; set;}
                                                          
                                                          public  		string
              dataList
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.hostingdata.jddp.data.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("tableName", this.            tableName
);
                                                                                                        parameters.Add("dataList", this.            dataList
);
                                                                                                                            }
    }
}





        
 

