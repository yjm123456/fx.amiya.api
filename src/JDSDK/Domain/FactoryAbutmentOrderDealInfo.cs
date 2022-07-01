using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FactoryAbutmentOrderDealInfo:JdObject{
      [JsonProperty("orderno")]
public 				string

             orderno
 { get; set; }
      [JsonProperty("returnCode")]
public 				string

             returnCode
 { get; set; }
	}
}
