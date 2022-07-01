using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQueryDeptRequest : JdRequestBase<EclpMasterQueryDeptResponse>
    {
                                                                                  public  		string
              deptNos
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.master.queryDept";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNos", this.            deptNos
);
                                                                                                    }
    }
}





        
 

