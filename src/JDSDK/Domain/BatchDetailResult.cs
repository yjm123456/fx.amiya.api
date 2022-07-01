using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchDetailResult:JdObject{
      [JsonProperty("batchQty")]
public 				int

             batchQty
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("orderLine")]
public 				string

             orderLine
 { get; set; }
      [JsonProperty("batAttrList")]
public 				List<string>

             batAttrList
 { get; set; }
	}
}
