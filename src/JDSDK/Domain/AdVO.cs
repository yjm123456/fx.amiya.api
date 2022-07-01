using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("size")]
public 				string

             size
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("createdTime")]
public 				DateTime

             createdTime
 { get; set; }
      [JsonProperty("modifiedTime")]
public 				DateTime

             modifiedTime
 { get; set; }
      [JsonProperty("adGroupId")]
public 				long

             adGroupId
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("imgUrl")]
public 				string

             imgUrl
 { get; set; }
      [JsonProperty("auditInfo")]
public 				string

             auditInfo
 { get; set; }
      [JsonProperty("spreadType")]
public 				int

             spreadType
 { get; set; }
      [JsonProperty("auditPerson")]
public 				string

             auditPerson
 { get; set; }
      [JsonProperty("auditTime")]
public 				DateTime

             auditTime
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("venderId")]
public 				int

             venderId
 { get; set; }
      [JsonProperty("cid3")]
public 				int

             cid3
 { get; set; }
      [JsonProperty("putType")]
public 				int

             putType
 { get; set; }
      [JsonProperty("imgFlag")]
public 				int

             imgFlag
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("isSpu")]
public 				int

             isSpu
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("campaignId")]
public 				long

             campaignId
 { get; set; }
      [JsonProperty("deliverySystemType")]
public 				int

             deliverySystemType
 { get; set; }
      [JsonProperty("customTitle")]
public 				string

             customTitle
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
	}
}
