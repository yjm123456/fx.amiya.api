using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoBoxModel:JdObject{
      [JsonProperty("boxNo")]
public 				string

             boxNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("realInstoreQty")]
public 				string

             realInstoreQty
 { get; set; }
	}
}
