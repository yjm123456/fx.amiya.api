using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbItem:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("lwbNo")]
public 				string

             lwbNo
 { get; set; }
      [JsonProperty("wbId")]
public 				long

             wbId
 { get; set; }
      [JsonProperty("sellerId")]
public 				long

             sellerId
 { get; set; }
      [JsonProperty("deptId")]
public 				long

             deptId
 { get; set; }
      [JsonProperty("packageNo")]
public 				string

             packageNo
 { get; set; }
      [JsonProperty("packageName")]
public 				string

             packageName
 { get; set; }
      [JsonProperty("length")]
public 					string

             length
 { get; set; }
      [JsonProperty("width")]
public 					string

             width
 { get; set; }
      [JsonProperty("height")]
public 					string

             height
 { get; set; }
      [JsonProperty("weight")]
public 					string

             weight
 { get; set; }
      [JsonProperty("volume")]
public 					string

             volume
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("updateUser")]
public 				string

             updateUser
 { get; set; }
      [JsonProperty("yn")]
public 				byte

             yn
 { get; set; }
      [JsonProperty("operateType")]
public 				byte

             operateType
 { get; set; }
      [JsonProperty("installFlag")]
public 				byte

             installFlag
 { get; set; }
      [JsonProperty("firstCategoryNo")]
public 				string

             firstCategoryNo
 { get; set; }
      [JsonProperty("firstCategoryName")]
public 				string

             firstCategoryName
 { get; set; }
      [JsonProperty("secondCategoryNo")]
public 				string

             secondCategoryNo
 { get; set; }
      [JsonProperty("secondCategoryName")]
public 				string

             secondCategoryName
 { get; set; }
      [JsonProperty("thirdCategoryNo")]
public 				string

             thirdCategoryNo
 { get; set; }
      [JsonProperty("thirdCategoryName")]
public 				string

             thirdCategoryName
 { get; set; }
      [JsonProperty("brandNo")]
public 				string

             brandNo
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("productSku")]
public 				string

             productSku
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("districtId")]
public 				int

             districtId
 { get; set; }
      [JsonProperty("streetId")]
public 				int

             streetId
 { get; set; }
      [JsonProperty("packageId")]
public 				long

             packageId
 { get; set; }
      [JsonProperty("productId")]
public 				string

             productId
 { get; set; }
	}
}
