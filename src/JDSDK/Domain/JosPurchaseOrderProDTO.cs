using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPurchaseOrderProDTO:JdObject{
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("vendorId")]
public 				string

             vendorId
 { get; set; }
      [JsonProperty("jdGlnCode")]
public 				string

             jdGlnCode
 { get; set; }
      [JsonProperty("glnCode")]
public 				string

             glnCode
 { get; set; }
      [JsonProperty("prePurchaseOrderCode")]
public 				string

             prePurchaseOrderCode
 { get; set; }
      [JsonProperty("purchaseOrderCode")]
public 				string

             purchaseOrderCode
 { get; set; }
      [JsonProperty("categoryNumber")]
public 				int

             categoryNumber
 { get; set; }
      [JsonProperty("totalNubmer")]
public 				int

             totalNubmer
 { get; set; }
      [JsonProperty("totalAmount")]
public 					string

             totalAmount
 { get; set; }
      [JsonProperty("actualTotalAmount")]
public 					string

             actualTotalAmount
 { get; set; }
      [JsonProperty("purchaseDate")]
public 				DateTime

             purchaseDate
 { get; set; }
      [JsonProperty("supposedArrivingDate")]
public 				DateTime

             supposedArrivingDate
 { get; set; }
      [JsonProperty("buyerContact")]
public 				string

             buyerContact
 { get; set; }
      [JsonProperty("departmentCode")]
public 				string

             departmentCode
 { get; set; }
      [JsonProperty("advanceOrder")]
public 				string

             advanceOrder
 { get; set; }
      [JsonProperty("orderAttribute")]
public 				string

             orderAttribute
 { get; set; }
      [JsonProperty("ouCode")]
public 				string

             ouCode
 { get; set; }
      [JsonProperty("orgName")]
public 				string

             orgName
 { get; set; }
      [JsonProperty("orgCode")]
public 				string

             orgCode
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("warehouse")]
public 				string

             warehouse
 { get; set; }
      [JsonProperty("warehouseGln")]
public 				string

             warehouseGln
 { get; set; }
      [JsonProperty("receiver")]
public 				string

             receiver
 { get; set; }
      [JsonProperty("receiverTel")]
public 				string

             receiverTel
 { get; set; }
      [JsonProperty("shippingAddress")]
public 				string

             shippingAddress
 { get; set; }
      [JsonProperty("station")]
public 				string

             station
 { get; set; }
      [JsonProperty("isTC")]
public 					bool

             isTC
 { get; set; }
      [JsonProperty("payment")]
public 				string

             payment
 { get; set; }
      [JsonProperty("backOrder")]
public 					bool

             backOrder
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
