using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchAttrStockResponse:JdObject{
      [JsonProperty("cursor")]
public 				string

             cursor
 { get; set; }
      [JsonProperty("batchAttrData")]
public 				List<string>

             batchAttrData
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
      [JsonProperty("responseCode")]
public 				int

             responseCode
 { get; set; }
	}
}
