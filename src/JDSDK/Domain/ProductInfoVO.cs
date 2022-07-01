using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductInfoVO:JdObject{
      [JsonProperty("imgUrl")]
public 				string

             imgUrl
 { get; set; }
      [JsonProperty("commentNum")]
public 				string

             commentNum
 { get; set; }
      [JsonProperty("mine")]
public 					bool

             mine
 { get; set; }
      [JsonProperty("groupName")]
public 				string

             groupName
 { get; set; }
      [JsonProperty("price")]
public 				string

             price
 { get; set; }
      [JsonProperty("campaignId")]
public 				string

             campaignId
 { get; set; }
      [JsonProperty("groupId")]
public 				string

             groupId
 { get; set; }
      [JsonProperty("haitou")]
public 					bool

             haitou
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("campaignName")]
public 				string

             campaignName
 { get; set; }
	}
}
