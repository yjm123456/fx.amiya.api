using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreQueryStoreHouseRentlistRequest : JdRequestBase<StoreQueryStoreHouseRentlistResponse>
    {
                                                                                                                   public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.store.queryStoreHouseRentlist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                    }
    }
}





        
 

