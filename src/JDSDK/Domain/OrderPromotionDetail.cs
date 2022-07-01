using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPromotionDetail:JdObject{
      [JsonProperty("saleTypeDesc")]
public 				string

             saleTypeDesc
 { get; set; }
      [JsonProperty("salePrice")]
public 				string

             salePrice
 { get; set; }
      [JsonProperty("promotionId")]
public 				long

             promotionId
 { get; set; }
      [JsonProperty("promotionName")]
public 				string

             promotionName
 { get; set; }
      [JsonProperty("beginTime")]
public 				string

             beginTime
 { get; set; }
      [JsonProperty("endTime")]
public 				string

             endTime
 { get; set; }
	}
}
