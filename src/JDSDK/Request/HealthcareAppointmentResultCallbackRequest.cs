using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HealthcareAppointmentResultCallbackRequest : JdRequestBase<HealthcareAppointmentResultCallbackResponse>
    {
                                                                                                                                              public  		string
              msg
 {get; set;}
                                                          
                                                          public  		string
              code
 {get; set;}
                                                          
                                                          public  		string
              reportId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdAppointmentId
 {get; set;}
                                                          
                                                                                           public  		string
              resultDate
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		string
              appointmentNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              resultType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.healthcare.appointmentResultCallback";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("msg", this.            msg
);
                                                                                                        parameters.Add("code", this.            code
);
                                                                                                        parameters.Add("reportId", this.            reportId
);
                                                                                                        parameters.Add("jdAppointmentId", this.            jdAppointmentId
);
                                                                                                                                                        parameters.Add("resultDate", this.            resultDate
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("appointmentNo", this.            appointmentNo
);
                                                                                                        parameters.Add("resultType", this.            resultType
);
                                                                            }
    }
}





        
 

