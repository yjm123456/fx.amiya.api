using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtsBatch:JdObject{
      [JsonProperty("deptGoodsNo")]
public 				string

             deptGoodsNo
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("quantity")]
public 				string

             quantity
 { get; set; }
      [JsonProperty("realQuantity")]
public 				string

             realQuantity
 { get; set; }
      [JsonProperty("batchNo")]
public 				string

             batchNo
 { get; set; }
      [JsonProperty("batAttrList")]
public 				List<string>

             batAttrList
 { get; set; }
      [JsonProperty("orderLine")]
public 				string

             orderLine
 { get; set; }
	}
}
