using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceDetailDto:JdObject{
      [JsonProperty("afsServiceDetailId")]
public 				int

             afsServiceDetailId
 { get; set; }
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("wareDescribe")]
public 				string

             wareDescribe
 { get; set; }
      [JsonProperty("wareBrand")]
public 				string

             wareBrand
 { get; set; }
      [JsonProperty("wareCid1")]
public 				int

             wareCid1
 { get; set; }
      [JsonProperty("wareCid2")]
public 				int

             wareCid2
 { get; set; }
      [JsonProperty("wareCid3")]
public 				int

             wareCid3
 { get; set; }
      [JsonProperty("createName")]
public 				string

             createName
 { get; set; }
      [JsonProperty("updateName")]
public 				string

             updateName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("updateDate")]
public 				DateTime

             updateDate
 { get; set; }
	}
}
