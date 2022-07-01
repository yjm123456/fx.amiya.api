using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSpuAttrDto:JdObject{
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
      [JsonProperty("mainSkuId")]
public 				long

             mainSkuId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("isZD")]
public 					bool

             isZD
 { get; set; }
      [JsonProperty("dataVersion")]
public 				int

             dataVersion
 { get; set; }
      [JsonProperty("attrValueId")]
public 				long

             attrValueId
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("jdSpuId")]
public 				long

             jdSpuId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("concurrentVersion")]
public 				int

             concurrentVersion
 { get; set; }
      [JsonProperty("b2bSpuId")]
public 				long

             b2bSpuId
 { get; set; }
      [JsonProperty("b2bSkuId")]
public 				long

             b2bSkuId
 { get; set; }
      [JsonProperty("attrId")]
public 				long

             attrId
 { get; set; }
      [JsonProperty("bizChannelEnum")]
public 				string

             bizChannelEnum
 { get; set; }
      [JsonProperty("spuPropertyType")]
public 				string

             spuPropertyType
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("attrValue")]
public 				string

             attrValue
 { get; set; }
      [JsonProperty("zdId")]
public 				long

             zdId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
