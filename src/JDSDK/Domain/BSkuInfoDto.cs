using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSkuInfoDto:JdObject{
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
      [JsonProperty("color")]
public 				string

             color
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("sizeSequence")]
public 				string

             sizeSequence
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("specSequence")]
public 				string

             specSequence
 { get; set; }
      [JsonProperty("channelFields")]
public 					Dictionary<string, object>

             channelFields
 { get; set; }
      [JsonProperty("saleDate")]
public 				string

             saleDate
 { get; set; }
      [JsonProperty("saleAttributes")]
public 				string

             saleAttributes
 { get; set; }
      [JsonProperty("colorSequence")]
public 				string

             colorSequence
 { get; set; }
      [JsonProperty("spec")]
public 				string

             spec
 { get; set; }
      [JsonProperty("b2bSkuId")]
public 				long

             b2bSkuId
 { get; set; }
      [JsonProperty("skuOffShelfTime")]
public 				string

             skuOffShelfTime
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("skuMark")]
public 				long

             skuMark
 { get; set; }
      [JsonProperty("modified")]
public 				string

             modified
 { get; set; }
      [JsonProperty("skuOnShelfTime")]
public 				string

             skuOnShelfTime
 { get; set; }
      [JsonProperty("wholesalePrice")]
public 					string

             wholesalePrice
 { get; set; }
      [JsonProperty("skuB2bSpecInfo")]
public 					Dictionary<string, object>

             skuB2bSpecInfo
 { get; set; }
      [JsonProperty("childSkus")]
public 				List<string>

             childSkus
 { get; set; }
      [JsonProperty("images")]
public 				List<string>

             images
 { get; set; }
      [JsonProperty("skuState")]
public 				int

             skuState
 { get; set; }
      [JsonProperty("dataVersion")]
public 				int

             dataVersion
 { get; set; }
      [JsonProperty("jdSpuId")]
public 				long

             jdSpuId
 { get; set; }
      [JsonProperty("created")]
public 				string

             created
 { get; set; }
      [JsonProperty("skuSpecInfo")]
public 					Dictionary<string, object>

             skuSpecInfo
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("b2bSpuId")]
public 				long

             b2bSpuId
 { get; set; }
      [JsonProperty("sizeNote")]
public 				string

             sizeNote
 { get; set; }
      [JsonProperty("skuBizArray")]
public 					Dictionary<string, object>

             skuBizArray
 { get; set; }
      [JsonProperty("thirdSkuId")]
public 				string

             thirdSkuId
 { get; set; }
      [JsonProperty("skuB2bBizInfo")]
public 					Dictionary<string, object>

             skuB2bBizInfo
 { get; set; }
      [JsonProperty("productCode")]
public 				string

             productCode
 { get; set; }
      [JsonProperty("size")]
public 				string

             size
 { get; set; }
      [JsonProperty("specName")]
public 				string

             specName
 { get; set; }
      [JsonProperty("mainJdSkuId")]
public 				long

             mainJdSkuId
 { get; set; }
      [JsonProperty("colorNote")]
public 				string

             colorNote
 { get; set; }
      [JsonProperty("outerId")]
public 				string

             outerId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
