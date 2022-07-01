using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSpuInfoDto:JdObject{
      [JsonProperty("jdSpuId")]
public 				long

             jdSpuId
 { get; set; }
      [JsonProperty("b2bSpuId")]
public 				long

             b2bSpuId
 { get; set; }
      [JsonProperty("spuName")]
public 				string

             spuName
 { get; set; }
      [JsonProperty("spuSource")]
public 				int

             spuSource
 { get; set; }
      [JsonProperty("leavedSpuId")]
public 				long

             leavedSpuId
 { get; set; }
      [JsonProperty("outerSpuId")]
public 				string

             outerSpuId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("venderColType")]
public 				int

             venderColType
 { get; set; }
      [JsonProperty("productColType")]
public 				int

             productColType
 { get; set; }
      [JsonProperty("spuType")]
public 				int

             spuType
 { get; set; }
      [JsonProperty("category")]
public 				string

             category
 { get; set; }
      [JsonProperty("firstCid")]
public 				int

             firstCid
 { get; set; }
      [JsonProperty("firstCidName")]
public 				string

             firstCidName
 { get; set; }
      [JsonProperty("secondCid")]
public 				int

             secondCid
 { get; set; }
      [JsonProperty("secondCidName")]
public 				string

             secondCidName
 { get; set; }
      [JsonProperty("thirdCid")]
public 				int

             thirdCid
 { get; set; }
      [JsonProperty("thirdCidName")]
public 				string

             thirdCidName
 { get; set; }
      [JsonProperty("spuState")]
public 				int

             spuState
 { get; set; }
      [JsonProperty("spuOnShelfTime")]
public 				string

             spuOnShelfTime
 { get; set; }
      [JsonProperty("spuOffShelfTime")]
public 				string

             spuOffShelfTime
 { get; set; }
      [JsonProperty("imagePath")]
public 				string

             imagePath
 { get; set; }
      [JsonProperty("brandId")]
public 				int

             brandId
 { get; set; }
      [JsonProperty("productionAreaId")]
public 				int

             productionAreaId
 { get; set; }
      [JsonProperty("productionArea")]
public 				string

             productionArea
 { get; set; }
      [JsonProperty("deliveryAreaId")]
public 				int

             deliveryAreaId
 { get; set; }
      [JsonProperty("dayLimitedSales")]
public 				int

             dayLimitedSales
 { get; set; }
      [JsonProperty("isPayFirst")]
public 				int

             isPayFirst
 { get; set; }
      [JsonProperty("packSpecification")]
public 				int

             packSpecification
 { get; set; }
      [JsonProperty("saleUnit")]
public 				string

             saleUnit
 { get; set; }
      [JsonProperty("carton")]
public 				string

             carton
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("weight")]
public 					string

             weight
 { get; set; }
      [JsonProperty("valueWeight")]
public 					string

             valueWeight
 { get; set; }
      [JsonProperty("saler")]
public 				string

             saler
 { get; set; }
      [JsonProperty("shangg")]
public 				string

             shangg
 { get; set; }
      [JsonProperty("buyer")]
public 				string

             buyer
 { get; set; }
      [JsonProperty("operater")]
public 				string

             operater
 { get; set; }
      [JsonProperty("salePlatform")]
public 				int

             salePlatform
 { get; set; }
      [JsonProperty("enBrand")]
public 				string

             enBrand
 { get; set; }
      [JsonProperty("cnBrand")]
public 				string

             cnBrand
 { get; set; }
      [JsonProperty("model")]
public 				string

             model
 { get; set; }
      [JsonProperty("shangJia")]
public 				string

             shangJia
 { get; set; }
      [JsonProperty("thirdSpuId")]
public 				string

             thirdSpuId
 { get; set; }
      [JsonProperty("upcCode")]
public 				string

             upcCode
 { get; set; }
      [JsonProperty("wholesalePrice")]
public 					string

             wholesalePrice
 { get; set; }
      [JsonProperty("pcDes")]
public 				string

             pcDes
 { get; set; }
      [JsonProperty("mobDes")]
public 				string

             mobDes
 { get; set; }
      [JsonProperty("channelFields")]
public 					Dictionary<string, object>

             channelFields
 { get; set; }
      [JsonProperty("specialProperty")]
public 					Dictionary<string, object>

             specialProperty
 { get; set; }
      [JsonProperty("b2bSpecialProperty")]
public 					Dictionary<string, object>

             b2bSpecialProperty
 { get; set; }
      [JsonProperty("dataVersion")]
public 				int

             dataVersion
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("created")]
public 				string

             created
 { get; set; }
      [JsonProperty("modified")]
public 				string

             modified
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("unLimitCid")]
public 				int

             unLimitCid
 { get; set; }
      [JsonProperty("unLimitCidName")]
public 				string

             unLimitCidName
 { get; set; }
	}
}
