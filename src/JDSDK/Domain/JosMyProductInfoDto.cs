using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosMyProductInfoDto:JdObject{
      [JsonProperty("result")]
public 				List<string>

             result
 { get; set; }
      [JsonProperty("count")]
public 				int

             count
 { get; set; }
      [JsonProperty("is_success")]
public 					bool

                                                                                     isSuccess
 { get; set; }
      [JsonProperty("return_code")]
public 				string

                                                                                     returnCode
 { get; set; }
      [JsonProperty("return_message")]
public 				string

                                                                                     returnMessage
 { get; set; }
	}
}
