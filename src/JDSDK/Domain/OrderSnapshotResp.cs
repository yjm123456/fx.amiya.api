using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderSnapshotResp:JdObject{
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("snapshot")]
public 				string

             snapshot
 { get; set; }
	}
}
