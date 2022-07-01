using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiPurchaseAddressAddRequest : JdRequestBase<YunpeiPurchaseAddressAddResponse>
    {
                                                                                                                   public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		string
              district
 {get; set;}
                                                          
                                                          public  		string
              street
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		string
              consignee
 {get; set;}
                                                          
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      isDefault
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.yunpei.purchase.address.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("district", this.            district
);
                                                                                                        parameters.Add("street", this.            street
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("consignee", this.            consignee
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                                                        parameters.Add("is_default", this.                                                                                    isDefault
);
                                                    }
    }
}





        
 

