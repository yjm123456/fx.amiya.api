using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCheckstockQueryCheckStockLossesRequest : JdRequestBase<EclpCheckstockQueryCheckStockLossesResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              checkStockNos
 {get; set;}
                                                          
                                                          public  		string
              pageNo
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                          public  		string
              returnIsvLotattrs
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.checkstock.queryCheckStockLosses";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("checkStockNos", this.            checkStockNos
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("returnIsvLotattrs", this.            returnIsvLotattrs
);
                                                                                                                            }
    }
}





        
 

