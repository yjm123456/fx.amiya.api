using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQueryShopRequest : JdRequestBase<EclpMasterQueryShopResponse>
    {
                                                                                                                                              public  		string
              shopNos
 {get; set;}
                                                          
                                                          public  		string
              isvShopNos
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.master.queryShop";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("shopNos", this.            shopNos
);
                                                                                                        parameters.Add("isvShopNos", this.            isvShopNos
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                                            }
    }
}





        
 

