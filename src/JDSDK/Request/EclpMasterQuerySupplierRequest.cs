using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQuerySupplierRequest : JdRequestBase<EclpMasterQuerySupplierResponse>
    {
                                                                                  public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              supplierNos
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.master.querySupplier";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("supplierNos", this.            supplierNos
);
                                                                                                    }
    }
}





        
 

