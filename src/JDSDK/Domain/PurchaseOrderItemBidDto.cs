using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseOrderItemBidDto:JdObject{
      [JsonProperty("purchaseId")]
public 				long

             purchaseId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("skuUnit")]
public 				string

             skuUnit
 { get; set; }
      [JsonProperty("categoryId")]
public 				long

             categoryId
 { get; set; }
      [JsonProperty("parentCategoryId")]
public 				long

             parentCategoryId
 { get; set; }
      [JsonProperty("rootCategoryId")]
public 				long

             rootCategoryId
 { get; set; }
      [JsonProperty("categoryFullName")]
public 				string

             categoryFullName
 { get; set; }
      [JsonProperty("vendorSkuUnit")]
public 				string

             vendorSkuUnit
 { get; set; }
      [JsonProperty("vendorSkuCount")]
public 				int

             vendorSkuCount
 { get; set; }
      [JsonProperty("vendorSkuName")]
public 				string

             vendorSkuName
 { get; set; }
      [JsonProperty("packageSpec")]
public 					string

             packageSpec
 { get; set; }
      [JsonProperty("onwayCount")]
public 					string

             onwayCount
 { get; set; }
      [JsonProperty("uselessCount")]
public 					string

             uselessCount
 { get; set; }
      [JsonProperty("stockinCount")]
public 					string

             stockinCount
 { get; set; }
      [JsonProperty("qualifiedCount")]
public 					string

             qualifiedCount
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("purchaseCode")]
public 				string

             purchaseCode
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("bomAiao")]
public 				int

             bomAiao
 { get; set; }
      [JsonProperty("status")]
public 				byte

             status
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
 { get; set; }
      [JsonProperty("skuSubType")]
public 				int

             skuSubType
 { get; set; }
      [JsonProperty("vendorSkuCode")]
public 				string

             vendorSkuCode
 { get; set; }
      [JsonProperty("skuCount")]
public 					string

             skuCount
 { get; set; }
      [JsonProperty("factoryId")]
public 				long

             factoryId
 { get; set; }
	}
}
