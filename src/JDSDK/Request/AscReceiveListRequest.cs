using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscReceiveListRequest : JdRequestBase<AscReceiveListResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeEnd
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              timeoutFlag
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              customerTel
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dealType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              customerExpect
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              jdInterveneFlag
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveResult
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveReasonCid1
 {get; set;}
                                                          
                                                          public  		string
              orderShopId
 {get; set;}
                                                          
                                                          public  		string
              returnShopId
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.receive.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("applyTimeBegin", this.            applyTimeBegin
);
                                                                                                        parameters.Add("applyTimeEnd", this.            applyTimeEnd
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("timeoutFlag", this.            timeoutFlag
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("dealType", this.            dealType
);
                                                                                                        parameters.Add("customerExpect", this.            customerExpect
);
                                                                                                        parameters.Add("jdInterveneFlag", this.            jdInterveneFlag
);
                                                                                                        parameters.Add("approveResult", this.            approveResult
);
                                                                                                        parameters.Add("approveReasonCid1", this.            approveReasonCid1
);
                                                                                                        parameters.Add("orderShopId", this.            orderShopId
);
                                                                                                        parameters.Add("returnShopId", this.            returnShopId
);
                                                                                                                                                parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

