using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcInStockSkuDto:JdObject{
      [JsonProperty("goodsSku")]
public 				string

             goodsSku
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("goodsCount")]
public 				string

             goodsCount
 { get; set; }
      [JsonProperty("companyCode")]
public 				string

             companyCode
 { get; set; }
      [JsonProperty("distribCenterCode")]
public 				string

             distribCenterCode
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
	}
}
