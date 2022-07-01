using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewGetSettleBillRequest : JdRequestBase<UeOrderNewGetSettleBillResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              dealType
 {get; set;}
                                                          
                                                          public  		string
              settleNo
 {get; set;}
                                                          
                                                          public  		string
              deliverType
 {get; set;}
                                                          
                                                          public  		string
              beginDate
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              invoiceNo
 {get; set;}
                                                          
                                                          public  		string
              dealRemark
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.getSettleBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("dealType", this.            dealType
);
                                                                                                        parameters.Add("settleNo", this.            settleNo
);
                                                                                                        parameters.Add("deliverType", this.            deliverType
);
                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("dealRemark", this.            dealRemark
);
                                                                            }
    }
}





        
 

