using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UlItemBatchResult:JdObject{
      [JsonProperty("orderLine")]
public 				string

             orderLine
 { get; set; }
      [JsonProperty("realQty")]
public 				int

             realQty
 { get; set; }
      [JsonProperty("batchNo")]
public 				string

             batchNo
 { get; set; }
      [JsonProperty("batchRefResultList")]
public 				List<string>

             batchRefResultList
 { get; set; }
	}
}
