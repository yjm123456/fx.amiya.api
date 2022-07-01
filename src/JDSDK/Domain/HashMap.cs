using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HashMap:JdObject{
      [JsonProperty("realPin")]
public 				string

             realPin
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
