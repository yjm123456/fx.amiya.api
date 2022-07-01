using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSalesReturnDto:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("serialNo")]
public 				string

             serialNo
 { get; set; }
      [JsonProperty("rkBusId")]
public 				string

             rkBusId
 { get; set; }
      [JsonProperty("rkTime")]
public 				DateTime

             rkTime
 { get; set; }
	}
}
