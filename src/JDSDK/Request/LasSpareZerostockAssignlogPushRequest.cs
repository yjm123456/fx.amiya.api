using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockAssignlogPushRequest : JdRequestBase<LasSpareZerostockAssignlogPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      afsNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                                                      afsSerTasNo
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                      traInf
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      actT
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.assignlog.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("afs_no", this.                                                                                    afsNo
);
                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("afs_ser_tas_no", this.                                                                                                                                                    afsSerTasNo
);
                                                                                                        parameters.Add("tra_inf", this.                                                                                    traInf
);
                                                                                                        parameters.Add("act_t", this.                                                                                    actT
);
                                                                            }
    }
}





        
 

