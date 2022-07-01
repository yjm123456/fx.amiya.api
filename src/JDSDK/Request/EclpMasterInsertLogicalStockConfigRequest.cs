using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterInsertLogicalStockConfigRequest : JdRequestBase<EclpMasterInsertLogicalStockConfigResponse>
    {
                                                                                                                                              public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              sellerName
 {get; set;}
                                                          
                                                          public  		string
              deptName
 {get; set;}
                                                          
                                                          public  		string
              factor1No
 {get; set;}
                                                          
                                                          public  		string
              factor1Name
 {get; set;}
                                                          
                                                          public  		string
              factor2No
 {get; set;}
                                                          
                                                          public  		string
              factor2Name
 {get; set;}
                                                          
                                                          public  		string
              factor3No
 {get; set;}
                                                          
                                                          public  		string
              factor3Name
 {get; set;}
                                                          
                                                          public  		string
              factor4No
 {get; set;}
                                                          
                                                          public  		string
              factor4Name
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.master.insertLogicalStockConfig";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("sellerName", this.            sellerName
);
                                                                                                        parameters.Add("deptName", this.            deptName
);
                                                                                                        parameters.Add("factor1No", this.            factor1No
);
                                                                                                        parameters.Add("factor1Name", this.            factor1Name
);
                                                                                                        parameters.Add("factor2No", this.            factor2No
);
                                                                                                        parameters.Add("factor2Name", this.            factor2Name
);
                                                                                                        parameters.Add("factor3No", this.            factor3No
);
                                                                                                        parameters.Add("factor3Name", this.            factor3Name
);
                                                                                                        parameters.Add("factor4No", this.            factor4No
);
                                                                                                        parameters.Add("factor4Name", this.            factor4Name
);
                                                                                                                            }
    }
}





        
 

