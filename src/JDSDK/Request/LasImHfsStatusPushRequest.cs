using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsStatusPushRequest : JdRequestBase<LasImHfsStatusPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      opeN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      serProNo
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                      opeT
 {get; set;}
                                                                                                                                  
                                                          public  		string
              rem
 {get; set;}
                                                          
                                                          public  		string
              det
 {get; set;}
                                                          
                                                          public  		string
              loc
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.status.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("ope_n", this.                                                                                    opeN
);
                                                                                                        parameters.Add("ser_pro_no", this.                                                                                                                    serProNo
);
                                                                                                        parameters.Add("ope_t", this.                                                                                    opeT
);
                                                                                                        parameters.Add("rem", this.            rem
);
                                                                                                        parameters.Add("det", this.            det
);
                                                                                                        parameters.Add("loc", this.            loc
);
                                                                            }
    }
}





        
 

