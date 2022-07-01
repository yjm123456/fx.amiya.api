using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarehouseStockResponse:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("sellerGoodsSign")]
public 				string

             sellerGoodsSign
 { get; set; }
      [JsonProperty("stockStatus")]
public 				string

             stockStatus
 { get; set; }
      [JsonProperty("stockType")]
public 				string

             stockType
 { get; set; }
      [JsonProperty("totalNum")]
public 				int[]

             totalNum
 { get; set; }
      [JsonProperty("usableNum")]
public 				int[]

             usableNum
 { get; set; }
      [JsonProperty("isvLotattrs")]
public 				string

             isvLotattrs
 { get; set; }
      [JsonProperty("ext1")]
public 				string

             ext1
 { get; set; }
      [JsonProperty("ext2")]
public 				string

             ext2
 { get; set; }
      [JsonProperty("ext3")]
public 				string

             ext3
 { get; set; }
      [JsonProperty("ext4")]
public 				string

             ext4
 { get; set; }
      [JsonProperty("ext5")]
public 				string

             ext5
 { get; set; }
      [JsonProperty("recordCount")]
public 				long

             recordCount
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("isvSku")]
public 				string

             isvSku
 { get; set; }
	}
}
