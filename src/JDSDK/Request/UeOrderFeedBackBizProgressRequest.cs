using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderFeedBackBizProgressRequest : JdRequestBase<UeOrderFeedBackBizProgressResponse>
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
              dealRemark
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.feedBackBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operateDate", this.            operateDate
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("dealRemark", this.            dealRemark
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                            }
    }
}





        
 

