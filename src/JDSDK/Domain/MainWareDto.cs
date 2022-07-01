using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MainWareDto:JdObject{
      [JsonProperty("mainWareSku")]
public 				long

             mainWareSku
 { get; set; }
      [JsonProperty("mainWareName")]
public 				string

             mainWareName
 { get; set; }
      [JsonProperty("mainWareSn")]
public 				string

             mainWareSn
 { get; set; }
      [JsonProperty("mainWareNum")]
public 				int

             mainWareNum
 { get; set; }
	}
}
