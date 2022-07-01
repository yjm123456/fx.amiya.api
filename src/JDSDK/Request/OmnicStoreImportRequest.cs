using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicStoreImportRequest : JdRequestBase<OmnicStoreImportResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              latitude
 {get; set;}
                                                          
                                                          public  		string
              storeContactName
 {get; set;}
                                                          
                                                          public  		string
              supplierCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townId
 {get; set;}
                                                          
                                                          public  		string
              storeContactTelephone
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              mapDatum
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              scopeType
 {get; set;}
                                                          
                                                          public  		string
              venderStoreName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyId
 {get; set;}
                                                          
                                                          public  		string
              storeFullAddress
 {get; set;}
                                                          
                                                          public  		string
              closeTime
 {get; set;}
                                                          
                                                          public  		string
              openTime
 {get; set;}
                                                          
                                                          public  		string
              longitude
 {get; set;}
                                                          
                                                          public  		string
              countyName
 {get; set;}
                                                          
                                                          public  		string
              coverage
 {get; set;}
                                                          
                                                          public  		string
              supplierName
 {get; set;}
                                                          
                                                          public  		string
              townName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  		string
              storeContactPhone
 {get; set;}
                                                          
                                                          public  		string
              venderStoreId
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		string
              vertexs
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.omnic.store.import";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                                                                                                parameters.Add("latitude", this.            latitude
);
                                                                                                        parameters.Add("storeContactName", this.            storeContactName
);
                                                                                                        parameters.Add("supplierCode", this.            supplierCode
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                        parameters.Add("storeContactTelephone", this.            storeContactTelephone
);
                                                                                                        parameters.Add("storeStatus", this.            storeStatus
);
                                                                                                        parameters.Add("mapDatum", this.            mapDatum
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("scopeType", this.            scopeType
);
                                                                                                        parameters.Add("venderStoreName", this.            venderStoreName
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("storeFullAddress", this.            storeFullAddress
);
                                                                                                        parameters.Add("closeTime", this.            closeTime
);
                                                                                                        parameters.Add("openTime", this.            openTime
);
                                                                                                        parameters.Add("longitude", this.            longitude
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("coverage", this.            coverage
);
                                                                                                        parameters.Add("supplierName", this.            supplierName
);
                                                                                                        parameters.Add("townName", this.            townName
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("storeContactPhone", this.            storeContactPhone
);
                                                                                                        parameters.Add("venderStoreId", this.            venderStoreId
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("vertexs", this.            vertexs
);
                                                                                                    }
    }
}





        
 

