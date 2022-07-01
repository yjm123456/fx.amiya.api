using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbStatusObjFLas:JdObject{
      [JsonProperty("waybillNo")]
public 				string

             waybillNo
 { get; set; }
      [JsonProperty("creationTime")]
public 				string

             creationTime
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("source")]
public 				string

             source
 { get; set; }
      [JsonProperty("operSystem")]
public 				string

             operSystem
 { get; set; }
      [JsonProperty("currentStatus")]
public 				string

             currentStatus
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("packageBarcode")]
public 				string

             packageBarcode
 { get; set; }
	}
}
