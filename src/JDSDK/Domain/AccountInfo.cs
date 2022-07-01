using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AccountInfo:JdObject{
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
	}
}
