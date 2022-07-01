using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AttributeSetting:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("cid")]
public 				long

             cid
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("attId")]
public 				int

             attId
 { get; set; }
      [JsonProperty("valueId")]
public 				int

             valueId
 { get; set; }
      [JsonProperty("value")]
public 				string

             value
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
