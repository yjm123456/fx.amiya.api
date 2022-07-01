using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OffsetResult:JdObject{
      [JsonProperty("suc")]
public 					bool

             suc
 { get; set; }
      [JsonProperty("content")]
public 				List<string>

             content
 { get; set; }
      [JsonProperty("err_cod")]
public 				int

                                                                                     errCod
 { get; set; }
      [JsonProperty("err_msg")]
public 				string

                                                                                     errMsg
 { get; set; }
	}
}
