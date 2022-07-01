using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnKeywordgroupListSearchRequest : JdRequestBase<KuaicheZnKeywordgroupListSearchResponse>
    {
                                                                                                                                                                                                                public  		Nullable<long>
                                                                                                                      thirdCategoryId
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      sortField
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      sortType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.keywordgroup.list.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("third_category_id", this.                                                                                                                    thirdCategoryId
);
                                                                                                        parameters.Add("sort_field", this.                                                                                    sortField
);
                                                                                                        parameters.Add("sort_type", this.                                                                                    sortType
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                            }
    }
}





        
 

