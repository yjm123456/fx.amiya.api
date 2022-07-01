using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IsvCheckStockDetail:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("diffQty")]
public 				string

             diffQty
 { get; set; }
      [JsonProperty("oneLevelReason")]
public 				string

             oneLevelReason
 { get; set; }
      [JsonProperty("twoLevelReason")]
public 				string

             twoLevelReason
 { get; set; }
      [JsonProperty("threeLevelReason")]
public 				string

             threeLevelReason
 { get; set; }
      [JsonProperty("productLevel")]
public 				string

             productLevel
 { get; set; }
      [JsonProperty("isvLotattrs")]
public 				string

             isvLotattrs
 { get; set; }
      [JsonProperty("batchInfoMap")]
public 				BatchAttrLosses

             batchInfoMap
 { get; set; }
	}
}
