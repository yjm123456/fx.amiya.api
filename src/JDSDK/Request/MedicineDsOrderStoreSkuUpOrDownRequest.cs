using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderStoreSkuUpOrDownRequest : JdRequestBase<MedicineDsOrderStoreSkuUpOrDownResponse>
    {
                                                                                                                                              public  		string
              exStoreId
 {get; set;}
                                                          
                                                                                           public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeSkuStatus
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              outerId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.storeSkuUpOrDown";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("exStoreId", this.            exStoreId
);
                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("storeSkuStatus", this.            storeSkuStatus
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("outerId", this.            outerId
);
                                                                            }
    }
}





        
 

