using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsCollectPushRequest : JdRequestBase<LasImHfsCollectPushResponse>
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
                                                                                                                                                          
                                                          public  		string
                                                                                      colNo
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      opeT
 {get; set;}
                                                                                                                                  
                                                          public  		string
              rem
 {get; set;}
                                                          
                                                          public  		string
                                                                                      disPho
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.collect.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("ope_n", this.                                                                                    opeN
);
                                                                                                        parameters.Add("ser_pro_no", this.                                                                                                                    serProNo
);
                                                                                                        parameters.Add("col_no", this.                                                                                    colNo
);
                                                                                                        parameters.Add("ope_t", this.                                                                                    opeT
);
                                                                                                        parameters.Add("rem", this.            rem
);
                                                                                                        parameters.Add("dis_pho", this.                                                                                    disPho
);
                                                                            }
    }
}





        
 

