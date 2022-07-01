using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopWareGpsApiOnlineRecordJosServiceQueryListRequest : JdRequestBase<PopWareGpsApiOnlineRecordJosServiceQueryListResponse>
    {
                                                                                  public  		string
              queryToJson
 {get; set;}
                                                          
                                                                                                                      public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              serviceId
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.pop.ware.gps.api.OnlineRecordJosService.queryList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("queryToJson", this.            queryToJson
);
                                                                                                                                                parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                                                                                            }
    }
}





        
 

