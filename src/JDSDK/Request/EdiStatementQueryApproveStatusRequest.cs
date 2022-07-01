using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiStatementQueryApproveStatusRequest : JdRequestBase<EdiStatementQueryApproveStatusResponse>
    {
                                                                                                                                                                               public  		string
              billNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.statement.queryApproveStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("billNo", this.            billNo
);
                                                                            }
    }
}





        
 

