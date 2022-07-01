using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Paragraph:JdObject{
      [JsonProperty("Content")]
public 				Content

             Content
 { get; set; }
      [JsonProperty("IcoTagInfo")]
public 				IcoTagInfo

             IcoTagInfo
 { get; set; }
      [JsonProperty("shop_id")]
public 				string

                                                                                     shopId
 { get; set; }
      [JsonProperty("wareid")]
public 				string

             wareid
 { get; set; }
      [JsonProperty("cid1")]
public 				string

             cid1
 { get; set; }
      [JsonProperty("cid2")]
public 				string

             cid2
 { get; set; }
      [JsonProperty("catid")]
public 				string

             catid
 { get; set; }
      [JsonProperty("good")]
public 				string

             good
 { get; set; }
      [JsonProperty("cod")]
public 				string

             cod
 { get; set; }
      [JsonProperty("ico")]
public 				string

             ico
 { get; set; }
      [JsonProperty("SlaveParagraph")]
public 				List<string>

             SlaveParagraph
 { get; set; }
	}
}
