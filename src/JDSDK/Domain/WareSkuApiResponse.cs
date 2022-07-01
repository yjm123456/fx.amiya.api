using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareSkuApiResponse:JdObject{
      [JsonProperty("skuList")]
public 				List<string>

             skuList
 { get; set; }
      [JsonProperty("messegeCode")]
public 				string

             messegeCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
