using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PropSetting:JdObject{
      [JsonProperty("pid")]
public 				int

             pid
 { get; set; }
      [JsonProperty("vid")]
public 				int

             vid
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("vname")]
public 				string

             vname
 { get; set; }
	}
}
