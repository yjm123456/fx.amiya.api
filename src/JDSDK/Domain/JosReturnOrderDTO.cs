using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosReturnOrderDTO:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("returnOrderCode")]
public 				string

             returnOrderCode
 { get; set; }
      [JsonProperty("deliveryNumber")]
public 				string

             deliveryNumber
 { get; set; }
      [JsonProperty("lineNumber")]
public 				int

             lineNumber
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
      [JsonProperty("returnDate")]
public 				DateTime

             returnDate
 { get; set; }
      [JsonProperty("shippingAddress")]
public 				string

             shippingAddress
 { get; set; }
      [JsonProperty("freightNum")]
public 				string

             freightNum
 { get; set; }
      [JsonProperty("pakagesNumber")]
public 				int

             pakagesNumber
 { get; set; }
      [JsonProperty("returnOrderStatus")]
public 				int

             returnOrderStatus
 { get; set; }
      [JsonProperty("productType")]
public 				int

             productType
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("orgCode")]
public 				string

             orgCode
 { get; set; }
      [JsonProperty("orgName")]
public 				string

             orgName
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("warehouse")]
public 				string

             warehouse
 { get; set; }
      [JsonProperty("operatorCode")]
public 				string

             operatorCode
 { get; set; }
      [JsonProperty("operatorName")]
public 				string

             operatorName
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("productState")]
public 				int

             productState
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("infoNote")]
public 				string

             infoNote
 { get; set; }
	}
}
