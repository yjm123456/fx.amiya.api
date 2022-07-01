using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChatSessionPage:JdObject{
      [JsonProperty("chatSessionList")]
public 				List<string>

             chatSessionList
 { get; set; }
      [JsonProperty("totalRecord")]
public 				int

             totalRecord
 { get; set; }
	}
}
