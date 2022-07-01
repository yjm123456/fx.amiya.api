using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockConfirmRequest : JdRequestBase<LasSpareZerostockConfirmResponse>
    {
                                                                                                                                              public  		string
                                                                                      afsNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      venCod
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      warDet
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.confirm";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("afs_no", this.                                                                                    afsNo
);
                                                                                                        parameters.Add("ven_cod", this.                                                                                    venCod
);
                                                                                                        parameters.Add("war_det", this.                                                                                    warDet
);
                                                                            }
    }
}





        
 

