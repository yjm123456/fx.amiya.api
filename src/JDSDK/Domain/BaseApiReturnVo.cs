using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BaseApiReturnVo:JdObject{
      [JsonProperty("rtnCode")]
public 				string

             rtnCode
 { get; set; }
      [JsonProperty("rtnMsg")]
public 				string

             rtnMsg
 { get; set; }
      [JsonProperty("rtnExt")]
public 				string

             rtnExt
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
