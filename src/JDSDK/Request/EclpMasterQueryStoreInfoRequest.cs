using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterQueryStoreInfoRequest : JdRequestBase<EclpMasterQueryStoreInfoResponse>
    {
                                                                                                                                              public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		string
              storeNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.master.queryStoreInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("storeNo", this.            storeNo
);
                                                                                                                            }
    }
}





        
 

