using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderSavesnRequest : JdRequestBase<OmnicOrderSavesnResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              venderStoreId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sn {get; set; }
                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.omnic.order.savesn";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("venderStoreId", this.            venderStoreId
);
                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("outSkuId", this.            outSkuId
);
                                                                                                        parameters.Add("sn", this.            sn
);
                                                                                                                                                    }
    }
}





        
 

