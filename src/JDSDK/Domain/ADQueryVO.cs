using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ADQueryVO:JdObject{
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
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
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
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("auditInfo")]
public 				string

             auditInfo
 { get; set; }
      [JsonProperty("putType")]
public 				int

             putType
 { get; set; }
      [JsonProperty("auditTime")]
public 				DateTime

             auditTime
 { get; set; }
      [JsonProperty("auditAdvice")]
public 				string

             auditAdvice
 { get; set; }
      [JsonProperty("outerAuditStatus")]
public 				string

             outerAuditStatus
 { get; set; }
	}
}
