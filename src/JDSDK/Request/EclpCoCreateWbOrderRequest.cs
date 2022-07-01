using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoCreateWbOrderRequest : JdRequestBase<EclpCoCreateWbOrderResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              senderNickName
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderMobile
 {get; set;}
                                                          
                                                          public  		string
              senderPhone
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
              senderProvinceName
 {get; set;}
                                                          
                                                          public  		string
              senderCityName
 {get; set;}
                                                          
                                                          public  		string
              senderCountyName
 {get; set;}
                                                          
                                                          public  		string
              senderTownName
 {get; set;}
                                                          
                                                          public  		string
              senderAddress
 {get; set;}
                                                          
                                                          public  		string
              receiverNickName
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              receiverMobile
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
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
                                                          
                                                          public  		string
              receiverProvinceName
 {get; set;}
                                                          
                                                          public  		string
              receiverCityName
 {get; set;}
                                                          
                                                          public  		string
              receiverCountyName
 {get; set;}
                                                          
                                                          public  		string
              receiverTownName
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              grossWeight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              grossVolume
 {get; set;}
                                                          
                                                          public  		string
              createTime
 {get; set;}
                                                          
                                                          public  		string
              createUser
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              receivable
 {get; set;}
                                                          
                                                          public  		string
              isCod
 {get; set;}
                                                          
                                                          public  		string
              vehicleTypeName
 {get; set;}
                                                          
                                                          public  		string
              vehicleTypeNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              vehicleQty
 {get; set;}
                                                          
                                                          public  		string
              expressItemName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              expressItemQty
 {get; set;}
                                                          
                                                          public  		string
              signReceiptFlag
 {get; set;}
                                                          
                                                          public  		string
              deliveryReceiptFlag
 {get; set;}
                                                          
                                                          public  		string
              deliveryIntoWarehouse
 {get; set;}
                                                          
                                                          public  		string
              loadFlag
 {get; set;}
                                                          
                                                          public  		string
              unloadFlag
 {get; set;}
                                                          
                                                          public  		string
              receiptFlag
 {get; set;}
                                                          
                                                          public  		string
              fcFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              guaranteeValue
 {get; set;}
                                                          
                                                          public  		string
              pickupBeginTime
 {get; set;}
                                                          
                                                          public  		string
              pickupEndTime
 {get; set;}
                                                          
                                                          public  		string
              bussinessType
 {get; set;}
                                                          
                                                          public  		string
              deliveryType
 {get; set;}
                                                          
                                                          public  		string
              senderCompany
 {get; set;}
                                                          
                                                          public  		string
              receiverCompany
 {get; set;}
                                                          
                                                          public  		string
              receiverAddress
 {get; set;}
                                                          
                                                          public  		string
              warehouseCode
 {get; set;}
                                                          
                                                          public  		string
              projectName
 {get; set;}
                                                          
                                                          public  		string
              actualSpId
 {get; set;}
                                                          
                                                          public  		string
              coldChainOn
 {get; set;}
                                                          
                                                          public  		string
              temptureNum
 {get; set;}
                                                          
                                                          public  		string
              qingzhenOn
 {get; set;}
                                                          
                                                          public  		string
              yiwuranOn
 {get; set;}
                                                          
                                                          public  		string
              inStorageNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              inStorageTime
 {get; set;}
                                                          
                                                          public  		string
              inStorageRemark
 {get; set;}
                                                          
                                                          public  		string
              heavyUpstair
 {get; set;}
                                                          
                                                          public  		string
              wayBillCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              spId
 {get; set;}
                                                          
                                                          public  		string
              saleOrderNo
 {get; set;}
                                                          
                                                          public  		string
              packageServiceOn
 {get; set;}
                                                          
                                                          public  		string
              deliveryMthd
 {get; set;}
                                                          
                                                          public  		string
              providerCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  packageNo {get; set; }
                                                                                                                                                                                                public  		string
              clientNo
 {get; set;}
                                                          
                                                          public  		string
              orderType
 {get; set;}
                                                          
                                                          public  		string
              siteCollect
 {get; set;}
                                                          
                                                          public  		string
              siteDelivery
 {get; set;}
                                                          
                                                          public  		string
              quarantineCert
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              selfCollectSiteId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              selfDeliverySiteId
 {get; set;}
                                                          
                                                          public  		string
              expectedArrivalStartTime
 {get; set;}
                                                          
                                                          public  		string
              expectedArrivalEndTime
 {get; set;}
                                                          
                                                          public  		string
              vehicleOrderNo
 {get; set;}
                                                          
                                                          public  		string
              messageSign
 {get; set;}
                                                          
                                                          public  		string
              checkPreSort
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  receiverNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverCompanySplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverMobileSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverPhoneSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverProvinceNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverProvinceSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverCityNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverCitySplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverCountyNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverCountySplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverTownNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverTownSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverAddressSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  expectedArrivalStartTimeSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  expectedArrivalEndTimeSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderNoSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  expressItemNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  grossVolumeSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  grossWeightSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  expressItemQtySplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  temptureNumSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quarantineCertSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  deliveryIntoWarehouseSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  inStorageNoSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  inStorageTimeSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  inStorageRemarkSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  loadFlagSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  unloadFlagSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  remarkSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageModelNosSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  qingzhenOnSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  yiwuranOnSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  receiverNickNameSplit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  guaranteeValueSplit {get; set; }
                                                                                                                                                                                                public  	    Nullable<double>
              isvOrderAmount
 {get; set;}
                                                          
                                                          public  		string
              tracker
 {get; set;}
                                                          
                                                          public  		string
              deliveryMode
 {get; set;}
                                                          
                                                          public  		string
              warehouseServiceType
 {get; set;}
                                                          
                                                          public  		string
              homeDeliveryOn
 {get; set;}
                                                          
                                                          public  		string
              siteCode
 {get; set;}
                                                          
                                                          public  		string
              referCancelDate
 {get; set;}
                                                          
                                                          public  		string
              rebackConfluenceOn
 {get; set;}
                                                          
                                                          public  		string
              expressDeliveryOn
 {get; set;}
                                                          
                                                          public  		string
              expectPickupDate
 {get; set;}
                                                          
                                                          public  		string
              expectDeliveryDate
 {get; set;}
                                                          
                                                          public  		string
              warehousePlatformName
 {get; set;}
                                                          
                                                          public  		string
              temporaryStorage
 {get; set;}
                                                          
                                                          public  		string
              predictReceiptDate
 {get; set;}
                                                          
                                                          public  		string
              extendFieldStr
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.co.createWbOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("senderNickName", this.            senderNickName
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderMobile", this.            senderMobile
);
                                                                                                        parameters.Add("senderPhone", this.            senderPhone
);
                                                                                                        parameters.Add("senderProvince", this.            senderProvince
);
                                                                                                        parameters.Add("senderCity", this.            senderCity
);
                                                                                                        parameters.Add("senderCounty", this.            senderCounty
);
                                                                                                        parameters.Add("senderTown", this.            senderTown
);
                                                                                                        parameters.Add("senderProvinceName", this.            senderProvinceName
);
                                                                                                        parameters.Add("senderCityName", this.            senderCityName
);
                                                                                                        parameters.Add("senderCountyName", this.            senderCountyName
);
                                                                                                        parameters.Add("senderTownName", this.            senderTownName
);
                                                                                                        parameters.Add("senderAddress", this.            senderAddress
);
                                                                                                        parameters.Add("receiverNickName", this.            receiverNickName
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("receiverProvince", this.            receiverProvince
);
                                                                                                        parameters.Add("receiverCity", this.            receiverCity
);
                                                                                                        parameters.Add("receiverCounty", this.            receiverCounty
);
                                                                                                        parameters.Add("receiverTown", this.            receiverTown
);
                                                                                                        parameters.Add("receiverProvinceName", this.            receiverProvinceName
);
                                                                                                        parameters.Add("receiverCityName", this.            receiverCityName
);
                                                                                                        parameters.Add("receiverCountyName", this.            receiverCountyName
);
                                                                                                        parameters.Add("receiverTownName", this.            receiverTownName
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("grossWeight", this.            grossWeight
);
                                                                                                        parameters.Add("grossVolume", this.            grossVolume
);
                                                                                                        parameters.Add("createTime", this.            createTime
);
                                                                                                        parameters.Add("createUser", this.            createUser
);
                                                                                                        parameters.Add("receivable", this.            receivable
);
                                                                                                        parameters.Add("isCod", this.            isCod
);
                                                                                                        parameters.Add("vehicleTypeName", this.            vehicleTypeName
);
                                                                                                        parameters.Add("vehicleTypeNo", this.            vehicleTypeNo
);
                                                                                                        parameters.Add("vehicleQty", this.            vehicleQty
);
                                                                                                        parameters.Add("expressItemName", this.            expressItemName
);
                                                                                                        parameters.Add("expressItemQty", this.            expressItemQty
);
                                                                                                        parameters.Add("signReceiptFlag", this.            signReceiptFlag
);
                                                                                                        parameters.Add("deliveryReceiptFlag", this.            deliveryReceiptFlag
);
                                                                                                        parameters.Add("deliveryIntoWarehouse", this.            deliveryIntoWarehouse
);
                                                                                                        parameters.Add("loadFlag", this.            loadFlag
);
                                                                                                        parameters.Add("unloadFlag", this.            unloadFlag
);
                                                                                                        parameters.Add("receiptFlag", this.            receiptFlag
);
                                                                                                        parameters.Add("fcFlag", this.            fcFlag
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                        parameters.Add("pickupBeginTime", this.            pickupBeginTime
);
                                                                                                        parameters.Add("pickupEndTime", this.            pickupEndTime
);
                                                                                                        parameters.Add("bussinessType", this.            bussinessType
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("senderCompany", this.            senderCompany
);
                                                                                                        parameters.Add("receiverCompany", this.            receiverCompany
);
                                                                                                        parameters.Add("receiverAddress", this.            receiverAddress
);
                                                                                                        parameters.Add("warehouseCode", this.            warehouseCode
);
                                                                                                        parameters.Add("projectName", this.            projectName
);
                                                                                                        parameters.Add("actualSpId", this.            actualSpId
);
                                                                                                        parameters.Add("coldChainOn", this.            coldChainOn
);
                                                                                                        parameters.Add("temptureNum", this.            temptureNum
);
                                                                                                        parameters.Add("qingzhenOn", this.            qingzhenOn
);
                                                                                                        parameters.Add("yiwuranOn", this.            yiwuranOn
);
                                                                                                        parameters.Add("inStorageNo", this.            inStorageNo
);
                                                                                                        parameters.Add("inStorageTime", this.            inStorageTime
);
                                                                                                        parameters.Add("inStorageRemark", this.            inStorageRemark
);
                                                                                                        parameters.Add("heavyUpstair", this.            heavyUpstair
);
                                                                                                        parameters.Add("wayBillCode", this.            wayBillCode
);
                                                                                                        parameters.Add("spId", this.            spId
);
                                                                                                        parameters.Add("saleOrderNo", this.            saleOrderNo
);
                                                                                                        parameters.Add("packageServiceOn", this.            packageServiceOn
);
                                                                                                        parameters.Add("deliveryMthd", this.            deliveryMthd
);
                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                                                                                                        parameters.Add("packageNo", this.            packageNo
);
                                                                                                                                                        parameters.Add("clientNo", this.            clientNo
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("siteCollect", this.            siteCollect
);
                                                                                                        parameters.Add("siteDelivery", this.            siteDelivery
);
                                                                                                        parameters.Add("quarantineCert", this.            quarantineCert
);
                                                                                                        parameters.Add("selfCollectSiteId", this.            selfCollectSiteId
);
                                                                                                        parameters.Add("selfDeliverySiteId", this.            selfDeliverySiteId
);
                                                                                                        parameters.Add("expectedArrivalStartTime", this.            expectedArrivalStartTime
);
                                                                                                        parameters.Add("expectedArrivalEndTime", this.            expectedArrivalEndTime
);
                                                                                                        parameters.Add("vehicleOrderNo", this.            vehicleOrderNo
);
                                                                                                        parameters.Add("messageSign", this.            messageSign
);
                                                                                                        parameters.Add("checkPreSort", this.            checkPreSort
);
                                                                                                                                                                                        parameters.Add("receiverNameSplit", this.            receiverNameSplit
);
                                                                                                        parameters.Add("receiverCompanySplit", this.            receiverCompanySplit
);
                                                                                                        parameters.Add("receiverMobileSplit", this.            receiverMobileSplit
);
                                                                                                        parameters.Add("receiverPhoneSplit", this.            receiverPhoneSplit
);
                                                                                                        parameters.Add("receiverProvinceNameSplit", this.            receiverProvinceNameSplit
);
                                                                                                        parameters.Add("receiverProvinceSplit", this.            receiverProvinceSplit
);
                                                                                                        parameters.Add("receiverCityNameSplit", this.            receiverCityNameSplit
);
                                                                                                        parameters.Add("receiverCitySplit", this.            receiverCitySplit
);
                                                                                                        parameters.Add("receiverCountyNameSplit", this.            receiverCountyNameSplit
);
                                                                                                        parameters.Add("receiverCountySplit", this.            receiverCountySplit
);
                                                                                                        parameters.Add("receiverTownNameSplit", this.            receiverTownNameSplit
);
                                                                                                        parameters.Add("receiverTownSplit", this.            receiverTownSplit
);
                                                                                                        parameters.Add("receiverAddressSplit", this.            receiverAddressSplit
);
                                                                                                        parameters.Add("expectedArrivalStartTimeSplit", this.            expectedArrivalStartTimeSplit
);
                                                                                                        parameters.Add("expectedArrivalEndTimeSplit", this.            expectedArrivalEndTimeSplit
);
                                                                                                        parameters.Add("orderNoSplit", this.            orderNoSplit
);
                                                                                                        parameters.Add("expressItemNameSplit", this.            expressItemNameSplit
);
                                                                                                        parameters.Add("grossVolumeSplit", this.            grossVolumeSplit
);
                                                                                                        parameters.Add("grossWeightSplit", this.            grossWeightSplit
);
                                                                                                        parameters.Add("expressItemQtySplit", this.            expressItemQtySplit
);
                                                                                                        parameters.Add("temptureNumSplit", this.            temptureNumSplit
);
                                                                                                        parameters.Add("quarantineCertSplit", this.            quarantineCertSplit
);
                                                                                                        parameters.Add("deliveryIntoWarehouseSplit", this.            deliveryIntoWarehouseSplit
);
                                                                                                        parameters.Add("inStorageNoSplit", this.            inStorageNoSplit
);
                                                                                                        parameters.Add("inStorageTimeSplit", this.            inStorageTimeSplit
);
                                                                                                        parameters.Add("inStorageRemarkSplit", this.            inStorageRemarkSplit
);
                                                                                                        parameters.Add("loadFlagSplit", this.            loadFlagSplit
);
                                                                                                        parameters.Add("unloadFlagSplit", this.            unloadFlagSplit
);
                                                                                                        parameters.Add("remarkSplit", this.            remarkSplit
);
                                                                                                        parameters.Add("packageModelNosSplit", this.            packageModelNosSplit
);
                                                                                                        parameters.Add("qingzhenOnSplit", this.            qingzhenOnSplit
);
                                                                                                        parameters.Add("yiwuranOnSplit", this.            yiwuranOnSplit
);
                                                                                                        parameters.Add("receiverNickNameSplit", this.            receiverNickNameSplit
);
                                                                                                        parameters.Add("guaranteeValueSplit", this.            guaranteeValueSplit
);
                                                                                                                                                        parameters.Add("isvOrderAmount", this.            isvOrderAmount
);
                                                                                                        parameters.Add("tracker", this.            tracker
);
                                                                                                        parameters.Add("deliveryMode", this.            deliveryMode
);
                                                                                                        parameters.Add("warehouseServiceType", this.            warehouseServiceType
);
                                                                                                        parameters.Add("homeDeliveryOn", this.            homeDeliveryOn
);
                                                                                                        parameters.Add("siteCode", this.            siteCode
);
                                                                                                        parameters.Add("referCancelDate", this.            referCancelDate
);
                                                                                                        parameters.Add("rebackConfluenceOn", this.            rebackConfluenceOn
);
                                                                                                        parameters.Add("expressDeliveryOn", this.            expressDeliveryOn
);
                                                                                                        parameters.Add("expectPickupDate", this.            expectPickupDate
);
                                                                                                        parameters.Add("expectDeliveryDate", this.            expectDeliveryDate
);
                                                                                                        parameters.Add("warehousePlatformName", this.            warehousePlatformName
);
                                                                                                        parameters.Add("temporaryStorage", this.            temporaryStorage
);
                                                                                                        parameters.Add("predictReceiptDate", this.            predictReceiptDate
);
                                                                                                        parameters.Add("extendFieldStr", this.            extendFieldStr
);
                                                                                                                            }
    }
}





        
 

