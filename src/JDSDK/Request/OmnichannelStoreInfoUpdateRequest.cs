using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelStoreInfoUpdateRequest : JdRequestBase<OmnichannelStoreInfoUpdateResponse>
    {
                                                                                                                                                                               public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              storeName
 {get; set;}
                                                          
                                                          public  		string
              storeFullAddress
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceCode
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		string
              county
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyCode
 {get; set;}
                                                          
                                                          public  		string
              town
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townCode
 {get; set;}
                                                          
                                                          public  		string
              storeContactName
 {get; set;}
                                                          
                                                          public  		string
              storeContactPhone
 {get; set;}
                                                          
                                                          public  		string
              storeContactMail
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              coverage
 {get; set;}
                                                          
                                                          public  		string
              companyUnitCreditCode
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              longitude
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              latitude
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isValid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryFlag
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pickupFlag
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.omnichannel.store.info.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("storeFullAddress", this.            storeFullAddress
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("provinceCode", this.            provinceCode
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("county", this.            county
);
                                                                                                        parameters.Add("countyCode", this.            countyCode
);
                                                                                                        parameters.Add("town", this.            town
);
                                                                                                        parameters.Add("townCode", this.            townCode
);
                                                                                                        parameters.Add("storeContactName", this.            storeContactName
);
                                                                                                        parameters.Add("storeContactPhone", this.            storeContactPhone
);
                                                                                                        parameters.Add("storeContactMail", this.            storeContactMail
);
                                                                                                        parameters.Add("coverage", this.            coverage
);
                                                                                                        parameters.Add("companyUnitCreditCode", this.            companyUnitCreditCode
);
                                                                                                        parameters.Add("longitude", this.            longitude
);
                                                                                                        parameters.Add("latitude", this.            latitude
);
                                                                                                        parameters.Add("isValid", this.            isValid
);
                                                                                                        parameters.Add("deliveryFlag", this.            deliveryFlag
);
                                                                                                        parameters.Add("pickupFlag", this.            pickupFlag
);
                                                                            }
    }
}





        
 

