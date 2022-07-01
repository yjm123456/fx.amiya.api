using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CarriersDetail:JdObject{
      [JsonProperty("carriers_id")]
public 				string

                                                                                     carriersId
 { get; set; }
      [JsonProperty("carriers_name")]
public 				string

                                                                                     carriersName
 { get; set; }
      [JsonProperty("carriers_phone")]
public 				string

                                                                                     carriersPhone
 { get; set; }
	}
}
