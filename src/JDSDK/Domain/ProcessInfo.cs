using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProcessInfo:JdObject{
      [JsonProperty("date")]
public 				string

             date
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("saleOrderNo")]
public 				string

             saleOrderNo
 { get; set; }
      [JsonProperty("shOrderNo")]
public 				string

             shOrderNo
 { get; set; }
      [JsonProperty("type")]
public 				string

             type
 { get; set; }
      [JsonProperty("resultType")]
public 				string

             resultType
 { get; set; }
      [JsonProperty("resultDesc")]
public 				string

             resultDesc
 { get; set; }
	}
}
