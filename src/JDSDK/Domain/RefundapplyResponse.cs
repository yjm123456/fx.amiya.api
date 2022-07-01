using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RefundapplyResponse:JdObject{
      [JsonProperty("count")]
public 				long

             count
 { get; set; }
      [JsonProperty("results")]
public 				List<string>

             results
 { get; set; }
      [JsonProperty("result_state")]
public 				bool

                                                                                     resultState
 { get; set; }
      [JsonProperty("result_info")]
public 				string

                                                                                     resultInfo
 { get; set; }
	}
}
