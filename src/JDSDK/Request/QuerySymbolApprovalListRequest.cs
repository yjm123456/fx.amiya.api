using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QuerySymbolApprovalListRequest : JdRequestBase<QuerySymbolApprovalListResponse>
    {
                                                                                                                                              public  		string
              approvalStatus
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              searchKey
 {get; set;}
                                                          
                                                          public  		string
              bdsBindTypeEnum
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                                                           public  		string
              symbolName
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.querySymbolApprovalList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("approvalStatus", this.            approvalStatus
);
                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("searchKey", this.            searchKey
);
                                                                                                        parameters.Add("bdsBindTypeEnum", this.            bdsBindTypeEnum
);
                                                                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                                                                        parameters.Add("symbolName", this.            symbolName
);
                                                                            }
    }
}





        
 

