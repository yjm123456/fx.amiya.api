using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConsigneeClient:JdObject{
      [JsonProperty("addressLevel1Id")]
public 				string

             addressLevel1Id
 { get; set; }
      [JsonProperty("addressLevel2Id")]
public 				string

             addressLevel2Id
 { get; set; }
      [JsonProperty("addressLevel3Id")]
public 				string

             addressLevel3Id
 { get; set; }
      [JsonProperty("addressLevel4Id")]
public 				string

             addressLevel4Id
 { get; set; }
      [JsonProperty("addressDetail")]
public 				string

             addressDetail
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("idCard")]
public 				string

             idCard
 { get; set; }
	}
}
