using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderStockIncreaseRequest : JdRequestBase<LdopAlphaProviderStockIncreaseResponse>
    {
                                                                                                                                              public  		string
              operatorCode
 {get; set;}
                                                          
                                                          public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              providerId
 {get; set;}
                                                          
                                                          public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		string
              providerName
 {get; set;}
                                                          
                                                          public  		string
              branchCode
 {get; set;}
                                                          
                                                          public  		string
              branchName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              amount
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorTime
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              state
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.stock.increase";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operatorCode", this.            operatorCode
);
                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("providerId", this.            providerId
);
                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("providerName", this.            providerName
);
                                                                                                        parameters.Add("branchCode", this.            branchCode
);
                                                                                                        parameters.Add("branchName", this.            branchName
);
                                                                                                        parameters.Add("amount", this.            amount
);
                                                                                                        parameters.Add("operatorTime", this.            operatorTime
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("state", this.            state
);
                                                                                                                            }
    }
}





        
 

