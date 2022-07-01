using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderGetStorePriceRequest : JdRequestBase<MedicineDsOrderGetStorePriceResponse>
    {
                                                                                                                                                                               public  		string
              outerId
 {get; set;}
                                                          
                                                          public  		string
              exStoreId
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.getStorePrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("outerId", this.            outerId
);
                                                                                                        parameters.Add("exStoreId", this.            exStoreId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                            }
    }
}





        
 

