using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CmpArticleStatusTimeVO:JdObject{
      [JsonProperty("statusTime")]
public 				long

             statusTime
 { get; set; }
      [JsonProperty("articleId")]
public 				int

             articleId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
