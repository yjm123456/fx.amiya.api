using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtwBatAttrModel:JdObject{
      [JsonProperty("deptGoodsNo")]
public 				string

             deptGoodsNo
 { get; set; }
      [JsonProperty("sellerGoodsNo")]
public 				string

             sellerGoodsNo
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
      [JsonProperty("isvSoNo")]
public 				string

             isvSoNo
 { get; set; }
      [JsonProperty("eclpSoNo")]
public 				string

             eclpSoNo
 { get; set; }
      [JsonProperty("batchOrderLine")]
public 				string

             batchOrderLine
 { get; set; }
      [JsonProperty("batAttrList")]
public 				List<string>

             batAttrList
 { get; set; }
	}
}
