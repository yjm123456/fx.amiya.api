using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryCancelAppointRequest : JdRequestBase<DentistryCancelAppointResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdAppointmentId
 {get; set;}
                                                          
                                                          public  		string
              appointmentNo
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dentistry.cancelAppoint";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("jdAppointmentId", this.            jdAppointmentId
);
                                                                                                        parameters.Add("appointmentNo", this.            appointmentNo
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                            }
    }
}





        
 

