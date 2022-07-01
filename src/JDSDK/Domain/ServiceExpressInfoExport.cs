using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceExpressInfoExport:JdObject{
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("freightMoney")]
public 					string

             freightMoney
 { get; set; }
      [JsonProperty("expressCompany")]
public 				string

             expressCompany
 { get; set; }
      [JsonProperty("deliveryDate")]
public 				DateTime

             deliveryDate
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("expressCode")]
public 				string

             expressCode
 { get; set; }
	}
}
