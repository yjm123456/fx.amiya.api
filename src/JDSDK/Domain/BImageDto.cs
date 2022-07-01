using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BImageDto:JdObject{
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
      [JsonProperty("imageId")]
public 				long

             imageId
 { get; set; }
      [JsonProperty("gmtModify")]
public 				DateTime

             gmtModify
 { get; set; }
      [JsonProperty("imagePath")]
public 				string

             imagePath
 { get; set; }
      [JsonProperty("colorId")]
public 				long

             colorId
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("shopSkuId")]
public 				long

             shopSkuId
 { get; set; }
      [JsonProperty("gmtCreate")]
public 				DateTime

             gmtCreate
 { get; set; }
      [JsonProperty("colorIdStr")]
public 				string

             colorIdStr
 { get; set; }
      [JsonProperty("imgZoneIdStr")]
public 				string

             imgZoneIdStr
 { get; set; }
      [JsonProperty("isPrimary")]
public 				bool

             isPrimary
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("imageType")]
public 				int

             imageType
 { get; set; }
      [JsonProperty("imgZoneId")]
public 				long

             imgZoneId
 { get; set; }
      [JsonProperty("imageIndex")]
public 				int

             imageIndex
 { get; set; }
	}
}
