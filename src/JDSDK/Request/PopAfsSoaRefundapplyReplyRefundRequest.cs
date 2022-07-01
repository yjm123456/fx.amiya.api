using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsSoaRefundapplyReplyRefundRequest : JdRequestBase<PopAfsSoaRefundapplyReplyRefundResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              checkUserName
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              rejectType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              outWareStatus
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.afs.soa.refundapply.replyRefund";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("checkUserName", this.            checkUserName
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("rejectType", this.            rejectType
);
                                                                                                        parameters.Add("outWareStatus", this.            outWareStatus
);
                                                                            }
    }
}





        
 

