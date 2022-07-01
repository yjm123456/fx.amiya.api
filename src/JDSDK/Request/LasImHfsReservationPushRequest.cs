using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsReservationPushRequest : JdRequestBase<LasImHfsReservationPushResponse>
    {
                                                                                                                                              public  		string
              orderid
 {get; set;}
                                                          
                                                          public  		string
              appointmentstatus
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              appointmenttimebegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              appointmenttimeend
 {get; set;}
                                                          
                                                          public  		string
              serviceproviderno
 {get; set;}
                                                          
                                                          public  		string
              operator1
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatetime
 {get; set;}
                                                          
                                                          public  		string
              ordertype
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.reservation.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderid", this.            orderid
);
                                                                                                        parameters.Add("appointmentstatus", this.            appointmentstatus
);
                                                                                                        parameters.Add("appointmenttimebegin", this.            appointmenttimebegin
);
                                                                                                        parameters.Add("appointmenttimeend", this.            appointmenttimeend
);
                                                                                                        parameters.Add("serviceproviderno", this.            serviceproviderno
);
                                                                                                        parameters.Add("operator", this.            operator1
);
                                                                                                        parameters.Add("operatetime", this.            operatetime
);
                                                                                                        parameters.Add("ordertype", this.            ordertype
);
                                                                            }
    }
}





        
 

