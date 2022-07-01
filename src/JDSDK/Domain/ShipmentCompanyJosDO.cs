using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShipmentCompanyJosDO:JdObject{
      [JsonProperty("companyId")]
public 				int

             companyId
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
	}
}
