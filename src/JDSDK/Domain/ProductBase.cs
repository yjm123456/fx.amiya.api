using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductBase:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("isDelete")]
public 				string

             isDelete
 { get; set; }
      [JsonProperty("state")]
public 				string

             state
 { get; set; }
      [JsonProperty("barCode")]
public 				string

             barCode
 { get; set; }
      [JsonProperty("erpPid")]
public 				string

             erpPid
 { get; set; }
      [JsonProperty("color")]
public 				string

             color
 { get; set; }
      [JsonProperty("colorSequence")]
public 				string

             colorSequence
 { get; set; }
      [JsonProperty("size")]
public 				string

             size
 { get; set; }
      [JsonProperty("sizeSequence")]
public 				string

             sizeSequence
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("skuMark")]
public 				string

             skuMark
 { get; set; }
      [JsonProperty("saleDate")]
public 				string

             saleDate
 { get; set; }
      [JsonProperty("cid2")]
public 				string

             cid2
 { get; set; }
      [JsonProperty("valueWeight")]
public 				string

             valueWeight
 { get; set; }
      [JsonProperty("weight")]
public 				string

             weight
 { get; set; }
      [JsonProperty("productArea")]
public 				string

             productArea
 { get; set; }
      [JsonProperty("wserve")]
public 				string

             wserve
 { get; set; }
      [JsonProperty("allnum")]
public 				string

             allnum
 { get; set; }
      [JsonProperty("maxPurchQty")]
public 				string

             maxPurchQty
 { get; set; }
      [JsonProperty("brandId")]
public 				string

             brandId
 { get; set; }
      [JsonProperty("valuePayFirst")]
public 				string

             valuePayFirst
 { get; set; }
      [JsonProperty("length")]
public 				string

             length
 { get; set; }
      [JsonProperty("width")]
public 				string

             width
 { get; set; }
      [JsonProperty("height")]
public 				string

             height
 { get; set; }
      [JsonProperty("venderType")]
public 				string

             venderType
 { get; set; }
      [JsonProperty("pname")]
public 				string

             pname
 { get; set; }
      [JsonProperty("issn")]
public 				string

             issn
 { get; set; }
      [JsonProperty("safeDays")]
public 				string

             safeDays
 { get; set; }
      [JsonProperty("saleUnit")]
public 				string

             saleUnit
 { get; set; }
      [JsonProperty("packSpecification")]
public 				string

             packSpecification
 { get; set; }
      [JsonProperty("category")]
public 				string

             category
 { get; set; }
      [JsonProperty("shopCategorys")]
public 				string

             shopCategorys
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("site")]
public 				string

             site
 { get; set; }
      [JsonProperty("ebrand")]
public 				string

             ebrand
 { get; set; }
      [JsonProperty("cbrand")]
public 				string

             cbrand
 { get; set; }
      [JsonProperty("model")]
public 				string

             model
 { get; set; }
      [JsonProperty("imagePath")]
public 				string

             imagePath
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
	}
}
