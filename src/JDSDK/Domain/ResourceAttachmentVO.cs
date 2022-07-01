using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResourceAttachmentVO:JdObject{
      [JsonProperty("pinScale")]
public 				long

             pinScale
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("seedId")]
public 				long

             seedId
 { get; set; }
      [JsonProperty("externalId")]
public 				string

             externalId
 { get; set; }
      [JsonProperty("packageName")]
public 				string

             packageName
 { get; set; }
      [JsonProperty("vaildEndTime")]
public 				DateTime

             vaildEndTime
 { get; set; }
	}
}
