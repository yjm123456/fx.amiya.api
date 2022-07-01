using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockAssigninfoPushRequest : JdRequestBase<LasSpareZerostockAssigninfoPushResponse>
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
                                                                                      sitNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sitN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sitTel
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      actT
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.assigninfo.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("afs_no", this.                                                                                    afsNo
);
                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("afs_ser_tas_no", this.                                                                                                                                                    afsSerTasNo
);
                                                                                                        parameters.Add("sit_no", this.                                                                                    sitNo
);
                                                                                                        parameters.Add("sit_n", this.                                                                                    sitN
);
                                                                                                        parameters.Add("sit_tel", this.                                                                                    sitTel
);
                                                                                                        parameters.Add("act_t", this.                                                                                    actT
);
                                                                            }
    }
}





        
 

