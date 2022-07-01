using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UploadToken:JdObject{
      [JsonProperty("upload_url")]
public 				string

                                                                                     uploadUrl
 { get; set; }
      [JsonProperty("start_time")]
public 				string

                                                                                     startTime
 { get; set; }
	}
}
