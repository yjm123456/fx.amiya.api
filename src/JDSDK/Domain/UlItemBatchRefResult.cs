using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UlItemBatchRefResult:JdObject{
      [JsonProperty("batchAttrKey")]
public 				string

             batchAttrKey
 { get; set; }
      [JsonProperty("batchAttrVal")]
public 				string

             batchAttrVal
 { get; set; }
	}
}
