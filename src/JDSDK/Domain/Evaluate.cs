using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Evaluate:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("saleOrderNo")]
public 				string

             saleOrderNo
 { get; set; }
      [JsonProperty("installContent")]
public 				string

             installContent
 { get; set; }
      [JsonProperty("skuContent")]
public 				string

             skuContent
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("installScore")]
public 				int

             installScore
 { get; set; }
      [JsonProperty("installTags")]
public 				string

             installTags
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("skuScore")]
public 				int

             skuScore
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("installDate")]
public 				DateTime

             installDate
 { get; set; }
      [JsonProperty("shDate")]
public 				DateTime

             shDate
 { get; set; }
      [JsonProperty("shScore")]
public 				int

             shScore
 { get; set; }
      [JsonProperty("shTags")]
public 				string

             shTags
 { get; set; }
	}
}
