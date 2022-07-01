using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HealthcarePushGoodsStoreInfoRequest : JdRequestBase<HealthcarePushGoodsStoreInfoResponse>
    {
                                                                                                                                              public  		string
              goodsId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.healthcare.pushGoodsStoreInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goodsId", this.            goodsId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                            }
    }
}





        
 

