using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNoFinishBizProgressRequest : JdRequestBase<UeOrderNoFinishBizProgressResponse>
    {
                                                                                                                                              public  		string
              operateDate
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              bookDate
 {get; set;}
                                                          
                                                          public  		string
              reason
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.noFinishBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operateDate", this.            operateDate
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("bookDate", this.            bookDate
);
                                                                                                        parameters.Add("reason", this.            reason
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                            }
    }
}





        
 

