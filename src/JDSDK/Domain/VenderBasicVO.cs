using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderBasicVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("venderCode")]
public 				string

             venderCode
 { get; set; }
      [JsonProperty("venderType")]
public 				int

             venderType
 { get; set; }
	}
}
