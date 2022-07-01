using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderModifyVenderRemarkRequest : JdRequestBase<PopOrderModifyVenderRemarkResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              flag
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.pop.order.modifyVenderRemark";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                                                                        parameters.Add("flag", this.            flag
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                            }
    }
}





        
 

