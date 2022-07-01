using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosNoticeClueVO:JdObject{
      [JsonProperty("clueId")]
public 				long

             clueId
 { get; set; }
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("spuTitle")]
public 				string

             spuTitle
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("type")]
public 			    short

             type
 { get; set; }
      [JsonProperty("submitTime")]
public 				DateTime

             submitTime
 { get; set; }
	}
}
