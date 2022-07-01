using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderSettleCheckBizProgressRequest : JdRequestBase<UeOrderSettleCheckBizProgressResponse>
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
              createBy
 {get; set;}
                                                          
                                                          public  		string
              settleCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.settleCheckBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operateDate", this.            operateDate
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("settleCode", this.            settleCode
);
                                                                            }
    }
}





        
 

