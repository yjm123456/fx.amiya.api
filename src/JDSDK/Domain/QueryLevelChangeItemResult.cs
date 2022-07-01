using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryLevelChangeItemResult:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("qty")]
public 				int

             qty
 { get; set; }
      [JsonProperty("reason1")]
public 				string

             reason1
 { get; set; }
      [JsonProperty("reason2")]
public 				string

             reason2
 { get; set; }
      [JsonProperty("reason3")]
public 				string

             reason3
 { get; set; }
      [JsonProperty("outLevel")]
public 				string

             outLevel
 { get; set; }
      [JsonProperty("intoLevel")]
public 				string

             intoLevel
 { get; set; }
      [JsonProperty("outLevelName")]
public 				string

             outLevelName
 { get; set; }
      [JsonProperty("intoLevelName")]
public 				string

             intoLevelName
 { get; set; }
      [JsonProperty("batchInfoMap")]
public 				BatchAttrLevel

             batchInfoMap
 { get; set; }
	}
}
