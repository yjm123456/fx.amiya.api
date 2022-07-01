using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TransMainExtItem:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsFunction")]
public 				string

             goodsFunction
 { get; set; }
      [JsonProperty("goodsLooking")]
public 				string

             goodsLooking
 { get; set; }
      [JsonProperty("attachment")]
public 				string

             attachment
 { get; set; }
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("goodsPackage")]
public 				string

             goodsPackage
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
	}
}
