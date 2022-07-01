using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseOutDetailDto:JdObject{
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
      [JsonProperty("remark1")]
public 				string

             remark1
 { get; set; }
      [JsonProperty("remark2")]
public 				string

             remark2
 { get; set; }
      [JsonProperty("remark3")]
public 				string

             remark3
 { get; set; }
      [JsonProperty("remark4")]
public 				string

             remark4
 { get; set; }
      [JsonProperty("remark5")]
public 				string

             remark5
 { get; set; }
	}
}
