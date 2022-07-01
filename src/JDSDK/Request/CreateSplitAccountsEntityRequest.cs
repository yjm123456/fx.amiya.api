using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CreateSplitAccountsEntityRequest : JdRequestBase<CreateSplitAccountsEntityResponse>
    {
                                                                                                                                              public  		string
              pin
 {get; set;}
                                                          
                                                                                           public  		string
              accountName
 {get; set;}
                                                          
                                                          public  		string
              walletName
 {get; set;}
                                                          
                                                          public  		string
              relStoreIds
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              defaultSplitType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.createSplitAccountsEntity";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                                                                        parameters.Add("accountName", this.            accountName
);
                                                                                                        parameters.Add("walletName", this.            walletName
);
                                                                                                        parameters.Add("relStoreIds", this.            relStoreIds
);
                                                                                                        parameters.Add("defaultSplitType", this.            defaultSplitType
);
                                                                            }
    }
}





        
 

