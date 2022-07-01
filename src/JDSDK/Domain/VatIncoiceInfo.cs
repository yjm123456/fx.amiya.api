using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VatIncoiceInfo:JdObject{
      [JsonProperty("vatNo")]
public 				string

             vatNo
 { get; set; }
      [JsonProperty("addressRegIstered")]
public 				string

             addressRegIstered
 { get; set; }
      [JsonProperty("phoneRegIstered")]
public 				string

             phoneRegIstered
 { get; set; }
      [JsonProperty("depositBank")]
public 				string

             depositBank
 { get; set; }
      [JsonProperty("bankAccount")]
public 				string

             bankAccount
 { get; set; }
      [JsonProperty("userAddress")]
public 				string

             userAddress
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("userPhone")]
public 				string

             userPhone
 { get; set; }
	}
}
