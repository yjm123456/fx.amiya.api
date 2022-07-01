using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageableResult:JdObject{
      [JsonProperty("shelfLifeGoodsResultList")]
public 				List<string>

             shelfLifeGoodsResultList
 { get; set; }
      [JsonProperty("recordCount")]
public 				long

             recordCount
 { get; set; }
	}
}
