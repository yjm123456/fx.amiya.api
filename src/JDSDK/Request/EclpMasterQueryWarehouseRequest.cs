using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQueryWarehouseRequest : JdRequestBase<EclpMasterQueryWarehouseResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNos
 {get; set;}
                                                          
                                                          public  		string
              status
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.master.queryWarehouse";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNos", this.            warehouseNos
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                            }
    }
}





        
 

