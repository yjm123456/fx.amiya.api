using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ObjExtAttrCollection:JdObject{
      [JsonProperty("expandsortid")]
public 				string

             expandsortid
 { get; set; }
      [JsonProperty("expandsortname")]
public 				string

             expandsortname
 { get; set; }
      [JsonProperty("sortorder")]
public 				string

             sortorder
 { get; set; }
      [JsonProperty("valueid")]
public 				string

             valueid
 { get; set; }
      [JsonProperty("valuename")]
public 				string

             valuename
 { get; set; }
	}
}
