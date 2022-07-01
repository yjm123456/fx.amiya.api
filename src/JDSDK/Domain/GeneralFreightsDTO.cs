using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GeneralFreightsDTO:JdObject{
      [JsonProperty("buNo")]
public 				string

             buNo
 { get; set; }
      [JsonProperty("businessNo")]
public 				string

             businessNo
 { get; set; }
      [JsonProperty("expDate")]
public 				DateTime

             expDate
 { get; set; }
      [JsonProperty("totalAmount")]
public 				double

             totalAmount
 { get; set; }
	}
}
