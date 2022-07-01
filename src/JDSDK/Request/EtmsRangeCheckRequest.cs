using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EtmsRangeCheckRequest : JdRequestBase<EtmsRangeCheckResponse>
    {
                                                                                                                                                                                                                public  		string
              salePlat
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              goodsType
 {get; set;}
                                                          
                                                          public  		string
              wareHouseCode
 {get; set;}
                                                          
                                                          public  		string
              receiveAddress
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              transType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              senderProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              senderCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              senderCountyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              senderTownId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiverProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiverCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiverCountyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiverTownId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              sendTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isCod
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              siteId
 {get; set;}
                                                          
                                                          public  		string
              siteName
 {get; set;}
                                                          
                                                          public  		string
              addedService
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              promiseTimeType
 {get; set;}
                                                          
                                                          public  		string
              senderAddress
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pickupSiteId
 {get; set;}
                                                          
                                                          public  		string
              pickupSiteCode
 {get; set;}
                                                          
                                                          public  		string
              siteCode
 {get; set;}
                                                          
                                                          public  		string
              senderProvince
 {get; set;}
                                                          
                                                          public  		string
              senderCity
 {get; set;}
                                                          
                                                          public  		string
              senderCounty
 {get; set;}
                                                          
                                                          public  		string
              senderTown
 {get; set;}
                                                          
                                                          public  		string
              receiverProvince
 {get; set;}
                                                          
                                                          public  		string
              receiverCity
 {get; set;}
                                                          
                                                          public  		string
              receiverCounty
 {get; set;}
                                                          
                                                          public  		string
              receiverTown
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              settleType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.etms.range.check";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("salePlat", this.            salePlat
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("goodsType", this.            goodsType
);
                                                                                                        parameters.Add("wareHouseCode", this.            wareHouseCode
);
                                                                                                        parameters.Add("receiveAddress", this.            receiveAddress
);
                                                                                                        parameters.Add("transType", this.            transType
);
                                                                                                        parameters.Add("senderProvinceId", this.            senderProvinceId
);
                                                                                                        parameters.Add("senderCityId", this.            senderCityId
);
                                                                                                        parameters.Add("senderCountyId", this.            senderCountyId
);
                                                                                                        parameters.Add("senderTownId", this.            senderTownId
);
                                                                                                        parameters.Add("receiverProvinceId", this.            receiverProvinceId
);
                                                                                                        parameters.Add("receiverCityId", this.            receiverCityId
);
                                                                                                        parameters.Add("receiverCountyId", this.            receiverCountyId
);
                                                                                                        parameters.Add("receiverTownId", this.            receiverTownId
);
                                                                                                        parameters.Add("sendTime", this.            sendTime
);
                                                                                                        parameters.Add("isCod", this.            isCod
);
                                                                                                        parameters.Add("siteId", this.            siteId
);
                                                                                                        parameters.Add("siteName", this.            siteName
);
                                                                                                        parameters.Add("addedService", this.            addedService
);
                                                                                                        parameters.Add("promiseTimeType", this.            promiseTimeType
);
                                                                                                        parameters.Add("senderAddress", this.            senderAddress
);
                                                                                                        parameters.Add("pickupSiteId", this.            pickupSiteId
);
                                                                                                        parameters.Add("pickupSiteCode", this.            pickupSiteCode
);
                                                                                                        parameters.Add("siteCode", this.            siteCode
);
                                                                                                        parameters.Add("senderProvince", this.            senderProvince
);
                                                                                                        parameters.Add("senderCity", this.            senderCity
);
                                                                                                        parameters.Add("senderCounty", this.            senderCounty
);
                                                                                                        parameters.Add("senderTown", this.            senderTown
);
                                                                                                        parameters.Add("receiverProvince", this.            receiverProvince
);
                                                                                                        parameters.Add("receiverCity", this.            receiverCity
);
                                                                                                        parameters.Add("receiverCounty", this.            receiverCounty
);
                                                                                                        parameters.Add("receiverTown", this.            receiverTown
);
                                                                                                        parameters.Add("settleType", this.            settleType
);
                                                                            }
    }
}





        
 

