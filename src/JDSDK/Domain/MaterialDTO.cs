using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialDTO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("materialType")]
public 				int

             materialType
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("level1CategoryId")]
public 				long

             level1CategoryId
 { get; set; }
      [JsonProperty("level1CategoryName")]
public 				string

             level1CategoryName
 { get; set; }
      [JsonProperty("level2CategoryId")]
public 				long

             level2CategoryId
 { get; set; }
      [JsonProperty("level2CategoryName")]
public 				string

             level2CategoryName
 { get; set; }
      [JsonProperty("level3CategoryId")]
public 				long

             level3CategoryId
 { get; set; }
      [JsonProperty("level3CategoryName")]
public 				string

             level3CategoryName
 { get; set; }
      [JsonProperty("categoryFullName")]
public 				string

             categoryFullName
 { get; set; }
      [JsonProperty("storageMethod")]
public 				string

             storageMethod
 { get; set; }
      [JsonProperty("spec")]
public 				string

             spec
 { get; set; }
      [JsonProperty("available")]
public 				bool

             available
 { get; set; }
      [JsonProperty("saleMode")]
public 				int

             saleMode
 { get; set; }
      [JsonProperty("saleUnit")]
public 				int

             saleUnit
 { get; set; }
      [JsonProperty("packingSpec")]
public 				string

             packingSpec
 { get; set; }
      [JsonProperty("singleSpec")]
public 				string

             singleSpec
 { get; set; }
      [JsonProperty("sizeSpec")]
public 				string

             sizeSpec
 { get; set; }
      [JsonProperty("length")]
public 					string

             length
 { get; set; }
      [JsonProperty("width")]
public 					string

             width
 { get; set; }
      [JsonProperty("high")]
public 					string

             high
 { get; set; }
      [JsonProperty("productionPlace")]
public 				string

             productionPlace
 { get; set; }
      [JsonProperty("labelName")]
public 				string

             labelName
 { get; set; }
      [JsonProperty("material")]
public 				string

             material
 { get; set; }
      [JsonProperty("acceptableRatio")]
public 					string

             acceptableRatio
 { get; set; }
      [JsonProperty("subType")]
public 				int

             subType
 { get; set; }
      [JsonProperty("rawMaterialType")]
public 				int

             rawMaterialType
 { get; set; }
      [JsonProperty("appearanceSpec")]
public 				string

             appearanceSpec
 { get; set; }
      [JsonProperty("customerSpec")]
public 				string

             customerSpec
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("creator")]
public 				string

             creator
 { get; set; }
	}
}
