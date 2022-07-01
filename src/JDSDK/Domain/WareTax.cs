using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareTax:JdObject{
      [JsonProperty("taxCode")]
public 				string

             taxCode
 { get; set; }
      [JsonProperty("taxRate")]
public 					string

             taxRate
 { get; set; }
      [JsonProperty("isTaxCheap")]
public 				int

             isTaxCheap
 { get; set; }
      [JsonProperty("taxCheapContent")]
public 				string

             taxCheapContent
 { get; set; }
      [JsonProperty("zeroTaxRate")]
public 				int

             zeroTaxRate
 { get; set; }
	}
}
