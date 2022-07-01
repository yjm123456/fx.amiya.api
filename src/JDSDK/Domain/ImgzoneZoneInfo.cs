using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImgzoneZoneInfo:JdObject{
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("used_size")]
public 				int

                                                                                     usedSize
 { get; set; }
      [JsonProperty("total_size")]
public 				int

                                                                                     totalSize
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
	}
}
