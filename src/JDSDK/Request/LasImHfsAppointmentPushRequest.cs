using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsAppointmentPushRequest : JdRequestBase<LasImHfsAppointmentPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      serProNo
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                      opeT
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      serDet
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.appointment.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("ser_pro_no", this.                                                                                                                    serProNo
);
                                                                                                        parameters.Add("ope_t", this.                                                                                    opeT
);
                                                                                                        parameters.Add("ser_det", this.                                                                                    serDet
);
                                                                            }
    }
}





        
 

