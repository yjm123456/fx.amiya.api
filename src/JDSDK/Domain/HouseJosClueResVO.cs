using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosClueResVO:JdObject{
      [JsonProperty("clueId")]
public 				int

             clueId
 { get; set; }
      [JsonProperty("clueRelationId")]
public 				long

             clueRelationId
 { get; set; }
      [JsonProperty("clueName")]
public 				string

             clueName
 { get; set; }
      [JsonProperty("clueType")]
public 				string

             clueType
 { get; set; }
      [JsonProperty("clueTime")]
public 				DateTime

             clueTime
 { get; set; }
      [JsonProperty("cluePhone")]
public 				string

             cluePhone
 { get; set; }
      [JsonProperty("cluePhoneName")]
public 				string

             cluePhoneName
 { get; set; }
	}
}
