using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDefaultResult:JdObject{
      [JsonProperty("eclpSoNo")]
public 				string

             eclpSoNo
 { get; set; }
      [JsonProperty("isvUUID")]
public 				string

             isvUUID
 { get; set; }
      [JsonProperty("wayBill")]
public 				string

             wayBill
 { get; set; }
      [JsonProperty("shipperNo")]
public 				string

             shipperNo
 { get; set; }
      [JsonProperty("shipperName")]
public 				string

             shipperName
 { get; set; }
      [JsonProperty("packCount")]
public 				int

             packCount
 { get; set; }
      [JsonProperty("orderPackageList")]
public 				List<string>

             orderPackageList
 { get; set; }
	}
}
