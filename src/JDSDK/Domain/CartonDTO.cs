using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CartonDTO:JdObject{
      [JsonProperty("cartonNo")]
public 				string

             cartonNo
 { get; set; }
      [JsonProperty("cartonItemList")]
public 				List<string>

             cartonItemList
 { get; set; }
	}
}
