using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FindStoresGroupListRequest : JdRequestBase<FindStoresGroupListResponse>
    {
                                                                                                                                                                               public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              businessId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              brandId
 {get; set;}
                                                          
                                                          public  		string
              creator
 {get; set;}
                                                          
                                                                                           public  		string
              pageIndex
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.findStoresGroupList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("businessId", this.            businessId
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                        parameters.Add("creator", this.            creator
);
                                                                                                                                parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

