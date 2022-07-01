using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewArriveRequest : JdRequestBase<UeOrderNewArriveResponse>
    {
                                                                                                                                              public  		string
              beginDate
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              deliverType
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.arrive";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("deliverType", this.            deliverType
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                            }
    }
}





        
 

