using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DetailFreightsDTO:JdObject{
      [JsonProperty("code1")]
public 				string

             code1
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("amount")]
public 				double

             amount
 { get; set; }
	}
}
