using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryUpdateAppointRequest : JdRequestBase<DentistryUpdateAppointResponse>
    {
                                                                                                                                              public  		string
              goodsId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		string
              appointEndTime
 {get; set;}
                                                          
                                                          public  		string
              appointBeginTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdAppointmentId
 {get; set;}
                                                          
                                                          public  		string
              appointmentNo
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              appointDate
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dentistry.updateAppoint";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goodsId", this.            goodsId
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("appointEndTime", this.            appointEndTime
);
                                                                                                        parameters.Add("appointBeginTime", this.            appointBeginTime
);
                                                                                                        parameters.Add("jdAppointmentId", this.            jdAppointmentId
);
                                                                                                        parameters.Add("appointmentNo", this.            appointmentNo
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("appointDate", this.            appointDate
);
                                                                                                                            }
    }
}





        
 

