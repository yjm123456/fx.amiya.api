using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OQueryResult:JdObject{
      [JsonProperty("serialNumbers")]
public 				List<string>

             serialNumbers
 { get; set; }
      [JsonProperty("totalRecords")]
public 				int

             totalRecords
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageNo")]
public 				int

             pageNo
 { get; set; }
	}
}
