using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConsumerResult:JdObject{
      [JsonProperty("result_code")]
public 				int

                                                                                     resultCode
 { get; set; }
      [JsonProperty("rsudoesult_message")]
public 				string

                                                                                     rsudoesultMessage
 { get; set; }
      [JsonProperty("is_success")]
public 				bool

                                                                                     isSuccess
 { get; set; }
	}
}
