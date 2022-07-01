using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopCategory:JdObject{
      [JsonProperty("id")]
public 				long[]

             id
 { get; set; }
      [JsonProperty("shopId")]
public 				long[]

             shopId
 { get; set; }
      [JsonProperty("parentId")]
public 				long[]

             parentId
 { get; set; }
      [JsonProperty("orderNo")]
public 				int[]

             orderNo
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("imgUri")]
public 				string

             imgUri
 { get; set; }
      [JsonProperty("open")]
public 				    bool[]

             open
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("homeShow")]
public 				int[]

             homeShow
 { get; set; }
	}
}
