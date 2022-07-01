using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillStockDTO:JdObject{
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("amount")]
public 				int

             amount
 { get; set; }
	}
}
