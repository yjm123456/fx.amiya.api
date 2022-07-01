using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPurchaseOrderDTO:JdObject{
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
      [JsonProperty("buyerContactId")]
public 				string

             buyerContactId
 { get; set; }
      [JsonProperty("buyerContact")]
public 				string

             buyerContact
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("shippingAddress")]
public 				string

             shippingAddress
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("warehouse")]
public 				string

             warehouse
 { get; set; }
      [JsonProperty("orderOwnerCode")]
public 				string

             orderOwnerCode
 { get; set; }
      [JsonProperty("orderOwner")]
public 				string

             orderOwner
 { get; set; }
      [JsonProperty("closingDate")]
public 				DateTime

             closingDate
 { get; set; }
      [JsonProperty("station")]
public 				string

             station
 { get; set; }
      [JsonProperty("payment")]
public 				string

             payment
 { get; set; }
      [JsonProperty("orgCode")]
public 				string

             orgCode
 { get; set; }
      [JsonProperty("orgName")]
public 				string

             orgName
 { get; set; }
      [JsonProperty("ouCode")]
public 				string

             ouCode
 { get; set; }
      [JsonProperty("comments")]
public 				string

             comments
 { get; set; }
      [JsonProperty("backOrder")]
public 					bool

             backOrder
 { get; set; }
      [JsonProperty("tcFlag")]
public 					bool

             tcFlag
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
