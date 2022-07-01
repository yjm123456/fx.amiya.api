using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSalesOutWarehouseResultDto:JdObject{
      [JsonProperty("recordCount")]
public 				int

             recordCount
 { get; set; }
      [JsonProperty("salesOutWarehouseList")]
public 				List<string>

             salesOutWarehouseList
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
	}
}
