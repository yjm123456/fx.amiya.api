using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderRemark:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("flag")]
public 				int

             flag
 { get; set; }
	}
}
