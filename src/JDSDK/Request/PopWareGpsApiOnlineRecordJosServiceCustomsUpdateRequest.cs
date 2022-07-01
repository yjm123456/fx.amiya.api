using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopWareGpsApiOnlineRecordJosServiceCustomsUpdateRequest : JdRequestBase<PopWareGpsApiOnlineRecordJosServiceCustomsUpdateResponse>
    {
                                                                                  public  		string
              recordingParamToJson
 {get; set;}
                                                          
                                                          public  		string
              recordedParamToJson
 {get; set;}
                                                          
                                                                                                                      public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              serviceId
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.pop.ware.gps.api.OnlineRecordJosService.customsUpdate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("recordingParamToJson", this.            recordingParamToJson
);
                                                                                                        parameters.Add("recordedParamToJson", this.            recordedParamToJson
);
                                                                                                                                                parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                                                                                            }
    }
}





        
 

