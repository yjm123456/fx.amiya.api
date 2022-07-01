using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AppointmentConfirmRequest : JdRequestBase<AppointmentConfirmResponse>
    {
                                                                                                                                              public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              asmsServiceId
 {get; set;}
                                                          
                                                          public  		string
              engineer
 {get; set;}
                                                          
                                                          public  		string
              engineerName
 {get; set;}
                                                          
                                                          public  		string
              appointmentTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.appointmentConfirm";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("asmsServiceId", this.            asmsServiceId
);
                                                                                                        parameters.Add("engineer", this.            engineer
);
                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("appointmentTime", this.            appointmentTime
);
                                                                            }
    }
}





        
 

