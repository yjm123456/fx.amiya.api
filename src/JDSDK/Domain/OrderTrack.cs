using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderTrack:JdObject{
      [JsonProperty("jdOrderId")]
public 				long

             jdOrderId
 { get; set; }
      [JsonProperty("trackShows")]
public 				List<string>

             trackShows
 { get; set; }
	}
}
