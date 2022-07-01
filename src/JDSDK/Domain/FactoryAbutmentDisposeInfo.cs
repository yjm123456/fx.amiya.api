using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FactoryAbutmentDisposeInfo:JdObject{
      [JsonProperty("orderno")]
public 				string

             orderno
 { get; set; }
      [JsonProperty("disposeTime")]
public 				DateTime

             disposeTime
 { get; set; }
      [JsonProperty("disposeResult")]
public 				int

             disposeResult
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
