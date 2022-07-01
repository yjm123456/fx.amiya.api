using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FactoryAbutmentServiceInfo:JdObject{
      [JsonProperty("orderno")]
public 				string

             orderno
 { get; set; }
      [JsonProperty("serviceTypeId")]
public 				int

             serviceTypeId
 { get; set; }
      [JsonProperty("serviceTypeName")]
public 				string

             serviceTypeName
 { get; set; }
	}
}
