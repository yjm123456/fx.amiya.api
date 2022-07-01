using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopStockFlowSub:JdObject{
      [JsonProperty("sellerNo")]
public 				string

             sellerNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("shopNo")]
public 				string

             shopNo
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("shopGoodsNo")]
public 				string

             shopGoodsNo
 { get; set; }
      [JsonProperty("bizNo")]
public 				string

             bizNo
 { get; set; }
      [JsonProperty("sellerGoodsSign")]
public 				string

             sellerGoodsSign
 { get; set; }
      [JsonProperty("spGoodsNo")]
public 				string

             spGoodsNo
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("occupyNum")]
public 				int

             occupyNum
 { get; set; }
      [JsonProperty("stockChangeNum")]
public 				int

             stockChangeNum
 { get; set; }
      [JsonProperty("occupyStockChangeNum")]
public 				int

             occupyStockChangeNum
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("bizType")]
public 				int

             bizType
 { get; set; }
	}
}
