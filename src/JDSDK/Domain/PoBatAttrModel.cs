using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoBatAttrModel:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("batchNo")]
public 				string

             batchNo
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("batchQty")]
public 				int

             batchQty
 { get; set; }
      [JsonProperty("batAttrList")]
public 				List<string>

             batAttrList
 { get; set; }
      [JsonProperty("orderLineNo")]
public 				string

             orderLineNo
 { get; set; }
      [JsonProperty("diffTypeName")]
public 				string

             diffTypeName
 { get; set; }
      [JsonProperty("isvLotattrs")]
public 				string

             isvLotattrs
 { get; set; }
	}
}
