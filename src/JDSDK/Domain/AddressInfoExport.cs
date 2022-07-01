using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AddressInfoExport:JdObject{
      [JsonProperty("province")]
public 				int

             province
 { get; set; }
      [JsonProperty("city")]
public 				int

             city
 { get; set; }
      [JsonProperty("county")]
public 				int

             county
 { get; set; }
      [JsonProperty("village")]
public 				int

             village
 { get; set; }
      [JsonProperty("detailAddress")]
public 				string

             detailAddress
 { get; set; }
	}
}
