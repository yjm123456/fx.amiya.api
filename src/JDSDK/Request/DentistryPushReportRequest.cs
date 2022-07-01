using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryPushReportRequest : JdRequestBase<DentistryPushReportResponse>
    {
                                                                                                                                              public  		string
              reportStr
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		string
              appiontmentNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdAppointmentId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dentistry.pushReport";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("reportStr", this.            reportStr
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("appiontmentNo", this.            appiontmentNo
);
                                                                                                        parameters.Add("jdAppointmentId", this.            jdAppointmentId
);
                                                                                                                            }
    }
}





        
 

