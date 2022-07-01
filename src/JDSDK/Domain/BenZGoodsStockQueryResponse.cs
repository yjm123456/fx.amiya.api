using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BenZGoodsStockQueryResponse:JdObject{
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
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("eclpGoodsName")]
public 				string

             eclpGoodsName
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("usableNum")]
public 				int

             usableNum
 { get; set; }
      [JsonProperty("shelfLifeDays")]
public 				string

             shelfLifeDays
 { get; set; }
      [JsonProperty("productionDate")]
public 				string

             productionDate
 { get; set; }
      [JsonProperty("expirationDate")]
public 				string

             expirationDate
 { get; set; }
      [JsonProperty("locDate")]
public 				string

             locDate
 { get; set; }
      [JsonProperty("remainDays")]
public 				string

             remainDays
 { get; set; }
      [JsonProperty("remainDaysRate")]
public 				string

             remainDaysRate
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
	}
}
