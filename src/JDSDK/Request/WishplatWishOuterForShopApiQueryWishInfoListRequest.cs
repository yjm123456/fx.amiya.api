using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WishplatWishOuterForShopApiQueryWishInfoListRequest : JdRequestBase<WishplatWishOuterForShopApiQueryWishInfoListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              wishTypeId
 {get; set;}
                                                          
                                                          public  		string
              startDate
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.wishplat.wishOuterForShopApi.queryWishInfoList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("wishTypeId", this.            wishTypeId
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                            }
    }
}





        
 

