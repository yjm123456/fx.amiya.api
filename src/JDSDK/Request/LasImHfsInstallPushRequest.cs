using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsInstallPushRequest : JdRequestBase<LasImHfsInstallPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      serProNo
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      verCod
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      opeT
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      opeN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      opeTel
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      insDet
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.install.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("ser_pro_no", this.                                                                                                                    serProNo
);
                                                                                                        parameters.Add("ver_cod", this.                                                                                    verCod
);
                                                                                                        parameters.Add("ope_t", this.                                                                                    opeT
);
                                                                                                        parameters.Add("ope_n", this.                                                                                    opeN
);
                                                                                                        parameters.Add("ope_tel", this.                                                                                    opeTel
);
                                                                                                        parameters.Add("ins_det", this.                                                                                    insDet
);
                                                                            }
    }
}





        
 

