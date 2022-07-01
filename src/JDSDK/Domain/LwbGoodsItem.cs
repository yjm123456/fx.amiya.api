using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbGoodsItem:JdObject{
      [JsonProperty("id")]
public 				long

             id
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
      [JsonProperty("skuCode")]
public 				string

             skuCode
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("quantity")]
public 				int

             quantity
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
	}
}
