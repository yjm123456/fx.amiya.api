using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChatLogPage:JdObject{
      [JsonProperty("chatLogList")]
public 				List<string>

             chatLogList
 { get; set; }
      [JsonProperty("totalRecord")]
public 				int

             totalRecord
 { get; set; }
	}
}
