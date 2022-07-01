using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbMain:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("lwbNo")]
public 				string

             lwbNo
 { get; set; }
      [JsonProperty("wbNo")]
public 				string

             wbNo
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("sendPay")]
public 				string

             sendPay
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deptId")]
public 				long

             deptId
 { get; set; }
      [JsonProperty("sellerId")]
public 				long

             sellerId
 { get; set; }
      [JsonProperty("sellerNo")]
public 				string

             sellerNo
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("statusDesc")]
public 				string

             statusDesc
 { get; set; }
      [JsonProperty("cancelStatus")]
public 				byte

             cancelStatus
 { get; set; }
      [JsonProperty("senderName")]
public 				string

             senderName
 { get; set; }
      [JsonProperty("senderMobile")]
public 				string

             senderMobile
 { get; set; }
      [JsonProperty("senderPhone")]
public 				string

             senderPhone
 { get; set; }
      [JsonProperty("senderProvince")]
public 				string

             senderProvince
 { get; set; }
      [JsonProperty("senderCity")]
public 				string

             senderCity
 { get; set; }
      [JsonProperty("senderCounty")]
public 				string

             senderCounty
 { get; set; }
      [JsonProperty("senderTown")]
public 				string

             senderTown
 { get; set; }
      [JsonProperty("senderProvinceName")]
public 				string

             senderProvinceName
 { get; set; }
      [JsonProperty("senderCityName")]
public 				string

             senderCityName
 { get; set; }
      [JsonProperty("senderCountyName")]
public 				string

             senderCountyName
 { get; set; }
      [JsonProperty("senderTownName")]
public 				string

             senderTownName
 { get; set; }
      [JsonProperty("senderAddress")]
public 				string

             senderAddress
 { get; set; }
      [JsonProperty("receiverName")]
public 				string

             receiverName
 { get; set; }
      [JsonProperty("receiverMobile")]
public 				string

             receiverMobile
 { get; set; }
      [JsonProperty("receiverPhone")]
public 				string

             receiverPhone
 { get; set; }
      [JsonProperty("receiverProvince")]
public 				string

             receiverProvince
 { get; set; }
      [JsonProperty("receiverCity")]
public 				string

             receiverCity
 { get; set; }
      [JsonProperty("receiverCounty")]
public 				string

             receiverCounty
 { get; set; }
      [JsonProperty("receiverTown")]
public 				string

             receiverTown
 { get; set; }
      [JsonProperty("receiverProvinceName")]
public 				string

             receiverProvinceName
 { get; set; }
      [JsonProperty("receiverCityName")]
public 				string

             receiverCityName
 { get; set; }
      [JsonProperty("receiverCountyName")]
public 				string

             receiverCountyName
 { get; set; }
      [JsonProperty("receiverTownName")]
public 				string

             receiverTownName
 { get; set; }
      [JsonProperty("receiverAddress")]
public 				string

             receiverAddress
 { get; set; }
      [JsonProperty("wholeReceiverAddress")]
public 				string

             wholeReceiverAddress
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("packageQty")]
public 				int

             packageQty
 { get; set; }
      [JsonProperty("predictArrivalDate")]
public 				DateTime

             predictArrivalDate
 { get; set; }
      [JsonProperty("reliability")]
public 				byte

             reliability
 { get; set; }
      [JsonProperty("grossWeight")]
public 					string

             grossWeight
 { get; set; }
      [JsonProperty("grossVolume")]
public 					string

             grossVolume
 { get; set; }
      [JsonProperty("isFragile")]
public 				byte

             isFragile
 { get; set; }
      [JsonProperty("source")]
public 				byte

             source
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("updateUser")]
public 				string

             updateUser
 { get; set; }
      [JsonProperty("yn")]
public 				byte

             yn
 { get; set; }
      [JsonProperty("lwbItem_list")]
public 				List<string>

                                                                                     lwbItemList
 { get; set; }
      [JsonProperty("lwbItemsStr")]
public 				string

             lwbItemsStr
 { get; set; }
      [JsonProperty("lwbStatus")]
public 				LwbStatus

             lwbStatus
 { get; set; }
      [JsonProperty("senderZip")]
public 				string

             senderZip
 { get; set; }
      [JsonProperty("transitCenterNo")]
public 				string

             transitCenterNo
 { get; set; }
      [JsonProperty("distributeNo")]
public 				string

             distributeNo
 { get; set; }
      [JsonProperty("logisticsServiceStoreId")]
public 				string

             logisticsServiceStoreId
 { get; set; }
      [JsonProperty("spId")]
public 				long

             spId
 { get; set; }
      [JsonProperty("receivable")]
public 				double

             receivable
 { get; set; }
      [JsonProperty("pinAccount")]
public 				string

             pinAccount
 { get; set; }
      [JsonProperty("isCod")]
public 				string

             isCod
 { get; set; }
      [JsonProperty("pickUpDate")]
public 				DateTime

             pickUpDate
 { get; set; }
      [JsonProperty("sourceType")]
public 				byte

             sourceType
 { get; set; }
      [JsonProperty("lwbGoodsItem_list")]
public 				List<string>

                                                                                     lwbGoodsItemList
 { get; set; }
      [JsonProperty("flowId")]
public 				int

             flowId
 { get; set; }
      [JsonProperty("operateType")]
public 				byte

             operateType
 { get; set; }
      [JsonProperty("orderDownloadTime")]
public 				string

             orderDownloadTime
 { get; set; }
      [JsonProperty("vehicleTypeName")]
public 				string

             vehicleTypeName
 { get; set; }
      [JsonProperty("vehicleTypeNo")]
public 				string

             vehicleTypeNo
 { get; set; }
      [JsonProperty("vehicleQty")]
public 				int

             vehicleQty
 { get; set; }
      [JsonProperty("expressItemName")]
public 				string

             expressItemName
 { get; set; }
      [JsonProperty("expressItemQty")]
public 				int

             expressItemQty
 { get; set; }
      [JsonProperty("guaranteeValue")]
public 					string

             guaranteeValue
 { get; set; }
      [JsonProperty("pickupBeginTime")]
public 				DateTime

             pickupBeginTime
 { get; set; }
      [JsonProperty("pickupEndTime")]
public 				DateTime

             pickupEndTime
 { get; set; }
      [JsonProperty("bussinessType")]
public 				byte

             bussinessType
 { get; set; }
      [JsonProperty("jdGrossWeight")]
public 					string

             jdGrossWeight
 { get; set; }
      [JsonProperty("deliveryType")]
public 				byte

             deliveryType
 { get; set; }
      [JsonProperty("senderNickName")]
public 				string

             senderNickName
 { get; set; }
      [JsonProperty("receiverNickName")]
public 				string

             receiverNickName
 { get; set; }
      [JsonProperty("sSendpay")]
public 				SSendpay

             sSendpay
 { get; set; }
      [JsonProperty("jdGrossVolume")]
public 					string

             jdGrossVolume
 { get; set; }
      [JsonProperty("siteId")]
public 				long

             siteId
 { get; set; }
      [JsonProperty("siteName")]
public 				string

             siteName
 { get; set; }
      [JsonProperty("siteType")]
public 				int

             siteType
 { get; set; }
      [JsonProperty("road")]
public 				string

             road
 { get; set; }
      [JsonProperty("senderCompany")]
public 				string

             senderCompany
 { get; set; }
      [JsonProperty("receiverCompany")]
public 				string

             receiverCompany
 { get; set; }
      [JsonProperty("bdOwnerNo")]
public 				string

             bdOwnerNo
 { get; set; }
      [JsonProperty("wbType")]
public 				byte

             wbType
 { get; set; }
      [JsonProperty("isprintFlag")]
public 				string

             isprintFlag
 { get; set; }
      [JsonProperty("waybillSign")]
public 				int

             waybillSign
 { get; set; }
      [JsonProperty("createType")]
public 				int

             createType
 { get; set; }
      [JsonProperty("reserve1")]
public 				string

             reserve1
 { get; set; }
      [JsonProperty("backName")]
public 				string

             backName
 { get; set; }
      [JsonProperty("backMobile")]
public 				string

             backMobile
 { get; set; }
      [JsonProperty("backPhone")]
public 				string

             backPhone
 { get; set; }
      [JsonProperty("backProvinceCode")]
public 				string

             backProvinceCode
 { get; set; }
      [JsonProperty("backCityCode")]
public 				string

             backCityCode
 { get; set; }
      [JsonProperty("backCountyCode")]
public 				string

             backCountyCode
 { get; set; }
      [JsonProperty("backTownCode")]
public 				string

             backTownCode
 { get; set; }
      [JsonProperty("backProvinceName")]
public 				string

             backProvinceName
 { get; set; }
      [JsonProperty("backCityName")]
public 				string

             backCityName
 { get; set; }
      [JsonProperty("backCountyName")]
public 				string

             backCountyName
 { get; set; }
      [JsonProperty("backTownName")]
public 				string

             backTownName
 { get; set; }
      [JsonProperty("backAddress")]
public 				string

             backAddress
 { get; set; }
      [JsonProperty("wholeBackAddress")]
public 				string

             wholeBackAddress
 { get; set; }
      [JsonProperty("pickupReturnReason")]
public 				string

             pickupReturnReason
 { get; set; }
      [JsonProperty("saleContactPhone")]
public 				string

             saleContactPhone
 { get; set; }
      [JsonProperty("productId")]
public 				string

             productId
 { get; set; }
      [JsonProperty("associateSoNo")]
public 				string

             associateSoNo
 { get; set; }
      [JsonProperty("isGuarantee")]
public 				byte

             isGuarantee
 { get; set; }
      [JsonProperty("statusSmallDesc")]
public 				string

             statusSmallDesc
 { get; set; }
      [JsonProperty("lwbStatusObjFLas")]
public 				LwbStatusObjFLas

             lwbStatusObjFLas
 { get; set; }
      [JsonProperty("isprintBoxFlag")]
public 				byte

             isprintBoxFlag
 { get; set; }
      [JsonProperty("jdExpressItemQty")]
public 				int

             jdExpressItemQty
 { get; set; }
      [JsonProperty("sellerWarehouseCode")]
public 				string

             sellerWarehouseCode
 { get; set; }
      [JsonProperty("projectName")]
public 				string

             projectName
 { get; set; }
      [JsonProperty("actualSpId")]
public 				string

             actualSpId
 { get; set; }
      [JsonProperty("predictReceiptDate")]
public 				DateTime

             predictReceiptDate
 { get; set; }
      [JsonProperty("upShelveTime")]
public 				DateTime

             upShelveTime
 { get; set; }
      [JsonProperty("downShelveTime")]
public 				DateTime

             downShelveTime
 { get; set; }
	}
}
