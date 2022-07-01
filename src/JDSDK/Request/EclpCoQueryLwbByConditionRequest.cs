using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoQueryLwbByConditionRequest : JdRequestBase<EclpCoQueryLwbByConditionResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.co.queryLwbByCondition";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                                            }
    }
}





        
 

