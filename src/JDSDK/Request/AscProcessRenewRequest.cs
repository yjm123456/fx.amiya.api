using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscProcessRenewRequest : JdRequestBase<AscProcessRenewResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		string
              operateRemark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sysVersion
 {get; set;}
                                                          
                                                          public  		string
              consigneeName
 {get; set;}
                                                          
                                                                                                                      public  		Nullable<int>
              provinceCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              villageCode
 {get; set;}
                                                          
                                                          public  		string
              detailAddress
 {get; set;}
                                                          
                                                                                           public  		string
              consigneeTel
 {get; set;}
                                                          
                                                          public  		string
              applyDescription
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryCenterId
 {get; set;}
                                                          
                                                          public  		string
              deliveryCenterName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeId
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              collectFreightFlag
 {get; set;}
                                                          
                                                          public  		string
              freightAmount
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  relationSkuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  relationWareType {get; set; }
                                                                                                                                                                                                public  		string
              extJsonStr
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdSeller
 {get; set;}
                                                                                                                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.asc.process.renew";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("operateRemark", this.            operateRemark
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("consigneeName", this.            consigneeName
);
                                                                                                                                                parameters.Add("provinceCode", this.            provinceCode
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("countyCode", this.            countyCode
);
                                                                                                        parameters.Add("villageCode", this.            villageCode
);
                                                                                                        parameters.Add("detailAddress", this.            detailAddress
);
                                                                                                                                parameters.Add("consigneeTel", this.            consigneeTel
);
                                                                                                        parameters.Add("applyDescription", this.            applyDescription
);
                                                                                                        parameters.Add("deliveryCenterId", this.            deliveryCenterId
);
                                                                                                        parameters.Add("deliveryCenterName", this.            deliveryCenterName
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("collectFreightFlag", this.            collectFreightFlag
);
                                                                                                        parameters.Add("freightAmount", this.            freightAmount
);
                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("wareName", this.            wareName
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                                                        parameters.Add("relationSkuId", this.            relationSkuId
);
                                                                                                        parameters.Add("relationWareType", this.            relationWareType
);
                                                                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                                                        parameters.Add("open_id_seller", this.                                                                                                                    openIdSeller
);
                                                                                                                            }
    }
}





        
 

