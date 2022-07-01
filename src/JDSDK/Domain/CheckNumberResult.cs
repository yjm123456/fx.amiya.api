using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CheckNumberResult:JdObject{
      [JsonProperty("result_code")]
public 				int

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
      [JsonProperty("is_success")]
public 				bool

                                                                                     isSuccess
 { get; set; }
      [JsonProperty("check_numbers")]
public 				List<string>

                                                                                     checkNumbers
 { get; set; }
	}
}
