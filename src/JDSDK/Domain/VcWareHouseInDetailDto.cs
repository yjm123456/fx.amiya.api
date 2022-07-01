using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseInDetailDto:JdObject{
      [JsonProperty("goodsSku")]
public 				string

             goodsSku
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("total")]
public 				int

             total
 { get; set; }
	}
}
