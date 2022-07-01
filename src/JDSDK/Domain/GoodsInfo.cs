using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GoodsInfo:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("sellerGoodsSign")]
public 				string

             sellerGoodsSign
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("spGoodsNo")]
public 				string

             spGoodsNo
 { get; set; }
      [JsonProperty("barcodes")]
public 				string

             barcodes
 { get; set; }
      [JsonProperty("thirdCategoryNo")]
public 				string

             thirdCategoryNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
	}
}
