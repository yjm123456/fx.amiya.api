using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderRelationCarrierResult:JdObject{
      [JsonProperty("carrierList")]
public 				List<string>

             carrierList
 { get; set; }
	}
}
