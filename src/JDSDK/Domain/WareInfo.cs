using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareInfo:JdObject{
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("wareStatus")]
public 				int

             wareStatus
 { get; set; }
      [JsonProperty("weight")]
public 				string

             weight
 { get; set; }
      [JsonProperty("mainImgPath")]
public 				string

             mainImgPath
 { get; set; }
      [JsonProperty("brandId")]
public 				string

             brandId
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("productArea")]
public 				string

             productArea
 { get; set; }
      [JsonProperty("barCode")]
public 				string

             barCode
 { get; set; }
      [JsonProperty("saleUnit")]
public 				string

             saleUnit
 { get; set; }
      [JsonProperty("wareDesc")]
public 				string

             wareDesc
 { get; set; }
      [JsonProperty("goodsType")]
public 				int

             goodsType
 { get; set; }
      [JsonProperty("hasChild")]
public 				bool

             hasChild
 { get; set; }
      [JsonProperty("childSkus")]
public 				string

             childSkus
 { get; set; }
      [JsonProperty("childNums")]
public 				string

             childNums
 { get; set; }
      [JsonProperty("lowestReferencePrice")]
public 					string

             lowestReferencePrice
 { get; set; }
      [JsonProperty("firstCatName")]
public 				string

             firstCatName
 { get; set; }
      [JsonProperty("firstCatId")]
public 				long

             firstCatId
 { get; set; }
      [JsonProperty("secondCatName")]
public 				string

             secondCatName
 { get; set; }
      [JsonProperty("secondCatId")]
public 				long

             secondCatId
 { get; set; }
      [JsonProperty("thirdCatName")]
public 				string

             thirdCatName
 { get; set; }
      [JsonProperty("thirdCatId")]
public 				long

             thirdCatId
 { get; set; }
	}
}
