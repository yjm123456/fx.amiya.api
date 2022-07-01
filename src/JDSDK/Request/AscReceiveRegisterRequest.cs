using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscReceiveRegisterRequest : JdRequestBase<AscReceiveRegisterResponse>
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
                                                          
                                                          public  		string
              receivePin
 {get; set;}
                                                          
                                                          public  		string
              receiveName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packingState
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              qualityState
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              invoiceRecord
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              judgmentReason
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              accessoryOrGift
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              appearanceState
 {get; set;}
                                                          
                                                          public  		string
              receiveRemark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              wareNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.receive.register";}
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
                                                                                                        parameters.Add("receivePin", this.            receivePin
);
                                                                                                        parameters.Add("receiveName", this.            receiveName
);
                                                                                                        parameters.Add("packingState", this.            packingState
);
                                                                                                        parameters.Add("qualityState", this.            qualityState
);
                                                                                                        parameters.Add("invoiceRecord", this.            invoiceRecord
);
                                                                                                        parameters.Add("judgmentReason", this.            judgmentReason
);
                                                                                                        parameters.Add("accessoryOrGift", this.            accessoryOrGift
);
                                                                                                        parameters.Add("appearanceState", this.            appearanceState
);
                                                                                                        parameters.Add("receiveRemark", this.            receiveRemark
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                            }
    }
}





        
 

