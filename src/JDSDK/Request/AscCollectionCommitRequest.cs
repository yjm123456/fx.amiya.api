using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscCollectionCommitRequest : JdRequestBase<AscCollectionCommitResponse>
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
              amount
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receivableType
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.collection.commit";}
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
                                                                                                        parameters.Add("amount", this.            amount
);
                                                                                                        parameters.Add("receivableType", this.            receivableType
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

