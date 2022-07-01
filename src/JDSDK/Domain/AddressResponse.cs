using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AddressResponse:JdObject{
      [JsonProperty("address")]
public 				List<string>

             address
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
	}
}
