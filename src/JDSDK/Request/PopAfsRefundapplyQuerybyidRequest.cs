using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsRefundapplyQuerybyidRequest : JdRequestBase<PopAfsRefundapplyQuerybyidResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      raId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.afs.refundapply.querybyid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("ra_id", this.                                                                                    raId
);
                                                    }
    }
}





        
 

