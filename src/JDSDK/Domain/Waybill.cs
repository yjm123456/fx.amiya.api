using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Waybill:JdObject{
      [JsonProperty("packageCode")]
public 				string

             packageCode
 { get; set; }
      [JsonProperty("weight")]
public 				double

             weight
 { get; set; }
      [JsonProperty("orderMark")]
public 				string

             orderMark
 { get; set; }
      [JsonProperty("origSortCenter")]
public 				string

             origSortCenter
 { get; set; }
      [JsonProperty("destSortCenter")]
public 				string

             destSortCenter
 { get; set; }
      [JsonProperty("origCrossCode")]
public 				string

             origCrossCode
 { get; set; }
      [JsonProperty("origTabletrolleyCode")]
public 				string

             origTabletrolleyCode
 { get; set; }
      [JsonProperty("destCrossCode")]
public 				string

             destCrossCode
 { get; set; }
      [JsonProperty("destTabletrolleyCode")]
public 				string

             destTabletrolleyCode
 { get; set; }
      [JsonProperty("siteId")]
public 				int

             siteId
 { get; set; }
      [JsonProperty("siteName")]
public 				string

             siteName
 { get; set; }
      [JsonProperty("road")]
public 				string

             road
 { get; set; }
      [JsonProperty("packageNum")]
public 				int

             packageNum
 { get; set; }
      [JsonProperty("packageCount")]
public 				int

             packageCount
 { get; set; }
      [JsonProperty("senderName")]
public 				string

             senderName
 { get; set; }
      [JsonProperty("senderMobile")]
public 				string

             senderMobile
 { get; set; }
      [JsonProperty("senderTel")]
public 				string

             senderTel
 { get; set; }
      [JsonProperty("senderAddress")]
public 				string

             senderAddress
 { get; set; }
      [JsonProperty("receiveName")]
public 				string

             receiveName
 { get; set; }
      [JsonProperty("receiveMobile")]
public 				string

             receiveMobile
 { get; set; }
      [JsonProperty("receiveTel")]
public 				string

             receiveTel
 { get; set; }
      [JsonProperty("receiveAddress")]
public 				string

             receiveAddress
 { get; set; }
      [JsonProperty("collectionMoney")]
public 				double

             collectionMoney
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("agingName")]
public 				string

             agingName
 { get; set; }
      [JsonProperty("customerCode")]
public 				string

             customerCode
 { get; set; }
      [JsonProperty("goodsType")]
public 				string

             goodsType
 { get; set; }
      [JsonProperty("sendCity")]
public 				string

             sendCity
 { get; set; }
      [JsonProperty("airTransport")]
public 				string

             airTransport
 { get; set; }
      [JsonProperty("guaranteeValue")]
public 				int

             guaranteeValue
 { get; set; }
      [JsonProperty("senderCompany")]
public 				string

             senderCompany
 { get; set; }
      [JsonProperty("receiveCompany")]
public 				string

             receiveCompany
 { get; set; }
      [JsonProperty("receiveProvince")]
public 				string

             receiveProvince
 { get; set; }
      [JsonProperty("receiveCity")]
public 				string

             receiveCity
 { get; set; }
      [JsonProperty("receiveCounty")]
public 				string

             receiveCounty
 { get; set; }
      [JsonProperty("truckSpot")]
public 				string

             truckSpot
 { get; set; }
      [JsonProperty("weightFlagText")]
public 				string

             weightFlagText
 { get; set; }
      [JsonProperty("jZDFlag")]
public 				string

             jZDFlag
 { get; set; }
      [JsonProperty("freightText")]
public 				string

             freightText
 { get; set; }
      [JsonProperty("receiptFlag")]
public 				string

             receiptFlag
 { get; set; }
      [JsonProperty("packageServiceOn")]
public 				string

             packageServiceOn
 { get; set; }
      [JsonProperty("goUpstairsOn")]
public 				string

             goUpstairsOn
 { get; set; }
      [JsonProperty("deliveryIntoWarehouse")]
public 				string

             deliveryIntoWarehouse
 { get; set; }
      [JsonProperty("transferCenterRouteList")]
public 				string

             transferCenterRouteList
 { get; set; }
      [JsonProperty("backupSiteId")]
public 				string

             backupSiteId
 { get; set; }
      [JsonProperty("backupSiteName")]
public 				string

             backupSiteName
 { get; set; }
      [JsonProperty("roadCode")]
public 				string

             roadCode
 { get; set; }
      [JsonProperty("temporaryStorage")]
public 				string

             temporaryStorage
 { get; set; }
	}
}
