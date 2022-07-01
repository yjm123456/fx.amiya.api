using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MediaVo:JdObject{
      [JsonProperty("fileUrl")]
public 				string

             fileUrl
 { get; set; }
      [JsonProperty("fileSize")]
public 				int

             fileSize
 { get; set; }
	}
}
