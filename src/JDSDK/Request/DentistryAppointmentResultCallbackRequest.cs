using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryAppointmentResultCallbackRequest : JdRequestBase<DentistryAppointmentResultCallbackResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              resultType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdAppointmentId
 {get; set;}
                                                          
                                                          public  		string
              code
 {get; set;}
                                                          
                                                          public  		string
              resultDate
 {get; set;}
                                                          
                                                          public  		string
              appointmentNo
 {get; set;}
                                                          
                                                          public  		string
              msg
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dentistry.appointmentResultCallback";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("resultType", this.            resultType
);
                                                                                                        parameters.Add("jdAppointmentId", this.            jdAppointmentId
);
                                                                                                        parameters.Add("code", this.            code
);
                                                                                                        parameters.Add("resultDate", this.            resultDate
);
                                                                                                        parameters.Add("appointmentNo", this.            appointmentNo
);
                                                                                                        parameters.Add("msg", this.            msg
);
                                                                                                                            }
    }
}





        
 

