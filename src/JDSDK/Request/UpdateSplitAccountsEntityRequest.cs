using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UpdateSplitAccountsEntityRequest : JdRequestBase<UpdateSplitAccountsEntityResponse>
    {
                                                                                                                                              public  		Nullable<long>
              splitId
 {get; set;}
                                                          
                                                                                           public  		string
              accountName
 {get; set;}
                                                          
                                                          public  		string
              relStoreIds
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.updateSplitAccountsEntity";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("splitId", this.            splitId
);
                                                                                                                                                        parameters.Add("accountName", this.            accountName
);
                                                                                                        parameters.Add("relStoreIds", this.            relStoreIds
);
                                                                            }
    }
}





        
 

