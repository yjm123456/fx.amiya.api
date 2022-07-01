using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GetResultInfoDTO:JdObject{
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("deliveryIdList")]
public 				List<string>

             deliveryIdList
 { get; set; }
	}
}
