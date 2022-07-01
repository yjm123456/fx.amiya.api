using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuInfoDto:JdObject{
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("uuid")]
public 				string

             uuid
 { get; set; }
      [JsonProperty("dim1_val")]
public 				string

                                                                                     dim1Val
 { get; set; }
      [JsonProperty("dim1_sort")]
public 				int

                                                                                     dim1Sort
 { get; set; }
      [JsonProperty("dim2_val")]
public 				string

                                                                                     dim2Val
 { get; set; }
      [JsonProperty("dim2_sort")]
public 				int

                                                                                     dim2Sort
 { get; set; }
      [JsonProperty("other_sale_attribute")]
public 				List<string>

                                                                                                                     otherSaleAttribute
 { get; set; }
      [JsonProperty("market_price")]
public 					string

                                                                                     marketPrice
 { get; set; }
      [JsonProperty("purchase_price")]
public 					string

                                                                                     purchasePrice
 { get; set; }
      [JsonProperty("member_price")]
public 					string

                                                                                     memberPrice
 { get; set; }
      [JsonProperty("weight")]
public 					string

             weight
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
	}
}
