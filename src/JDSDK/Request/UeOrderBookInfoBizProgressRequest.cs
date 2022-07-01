using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderBookInfoBizProgressRequest : JdRequestBase<UeOrderBookInfoBizProgressResponse>
    {
                                                                                                                                              public  		string
              bookBy
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              bookDate
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                                          public  		string
              bookOperateDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.bookInfoBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("bookBy", this.            bookBy
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("bookDate", this.            bookDate
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("bookOperateDate", this.            bookOperateDate
);
                                                                            }
    }
}





        
 

