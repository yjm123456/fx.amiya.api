using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VendorProductBidDto:JdObject{
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("vendorNameAbbr")]
public 				string

             vendorNameAbbr
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
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
      [JsonProperty("unit")]
public 				string

             unit
 { get; set; }
      [JsonProperty("packageSpec")]
public 					string

             packageSpec
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("buyRatio")]
public 					string

             buyRatio
 { get; set; }
      [JsonProperty("purchaseMan")]
public 				string

             purchaseMan
 { get; set; }
      [JsonProperty("stockInVendor")]
public 				string

             stockInVendor
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("available")]
public 				bool

             available
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
