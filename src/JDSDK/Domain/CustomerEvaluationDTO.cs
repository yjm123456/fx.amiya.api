using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerEvaluationDTO:JdObject{
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("score")]
public 				string

             score
 { get; set; }
      [JsonProperty("creationTime")]
public 				string

             creationTime
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("maxPage")]
public 				int

             maxPage
 { get; set; }
	}
}
