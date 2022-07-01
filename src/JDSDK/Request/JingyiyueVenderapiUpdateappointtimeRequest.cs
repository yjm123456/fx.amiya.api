using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JingyiyueVenderapiUpdateappointtimeRequest : JdRequestBase<JingyiyueVenderapiUpdateappointtimeResponse>
    {
                                                                                                                                              public  		string
              sourceKey
 {get; set;}
                                                          
                                                          public  		string
              appointStartTime
 {get; set;}
                                                          
                                                                                           public  		string
              appointOrderId
 {get; set;}
                                                          
                                                          public  		string
              venderOrderId
 {get; set;}
                                                          
                                                          public  		string
              appointEndTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jingyiyue.venderapi.updateappointtime";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sourceKey", this.            sourceKey
);
                                                                                                        parameters.Add("appointStartTime", this.            appointStartTime
);
                                                                                                                                                        parameters.Add("appointOrderId", this.            appointOrderId
);
                                                                                                        parameters.Add("venderOrderId", this.            venderOrderId
);
                                                                                                        parameters.Add("appointEndTime", this.            appointEndTime
);
                                                                            }
    }
}





        
 

