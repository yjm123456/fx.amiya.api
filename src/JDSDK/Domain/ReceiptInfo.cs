using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReceiptInfo:JdObject{
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
	}
}
