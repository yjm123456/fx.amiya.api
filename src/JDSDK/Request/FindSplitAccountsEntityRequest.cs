using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FindSplitAccountsEntityRequest : JdRequestBase<FindSplitAccountsEntityResponse>
    {
                                                                                                                                              public  		Nullable<long>
              splitId
 {get; set;}
                                                          
                                                                                           public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              index
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.findSplitAccountsEntity";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("splitId", this.            splitId
);
                                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("index", this.            index
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

