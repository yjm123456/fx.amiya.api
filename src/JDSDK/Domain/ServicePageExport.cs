using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServicePageExport:JdObject{
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("pageNumer")]
public 				int

             pageNumer
 { get; set; }
      [JsonProperty("serviceExportList")]
public 				List<string>

             serviceExportList
 { get; set; }
	}
}
