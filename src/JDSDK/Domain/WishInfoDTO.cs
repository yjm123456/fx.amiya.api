using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WishInfoDTO:JdObject{
      [JsonProperty("wishTypeId")]
public 				int

             wishTypeId
 { get; set; }
      [JsonProperty("wishSourceId")]
public 				int

             wishSourceId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("wishNo")]
public 				string

             wishNo
 { get; set; }
      [JsonProperty("wishInfo")]
public 				string

             wishInfo
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
	}
}
