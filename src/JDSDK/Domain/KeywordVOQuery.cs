using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class KeywordVOQuery:JdObject{
      [JsonProperty("keywordName")]
public 				string

             keywordName
 { get; set; }
      [JsonProperty("searchCount")]
public 				string

             searchCount
 { get; set; }
	}
}
