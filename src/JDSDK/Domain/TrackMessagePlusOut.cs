using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TrackMessagePlusOut:JdObject{
      [JsonProperty("opeTitle")]
public 				string

             opeTitle
 { get; set; }
      [JsonProperty("opeRemark")]
public 				string

             opeRemark
 { get; set; }
      [JsonProperty("opeName")]
public 				string

             opeName
 { get; set; }
      [JsonProperty("opeTime")]
public 				string

             opeTime
 { get; set; }
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
	}
}
