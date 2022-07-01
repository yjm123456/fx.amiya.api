using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtsDetail:JdObject{
      [JsonProperty("deptGoodsNo")]
public 				string

             deptGoodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("quantity")]
public 				string

             quantity
 { get; set; }
      [JsonProperty("realQuantity")]
public 				string

             realQuantity
 { get; set; }
      [JsonProperty("goodsStatus")]
public 				string

             goodsStatus
 { get; set; }
	}
}
