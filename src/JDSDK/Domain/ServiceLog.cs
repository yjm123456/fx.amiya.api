using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceLog:JdObject{
      [JsonProperty("afsLogId")]
public 				long

             afsLogId
 { get; set; }
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("relationType")]
public 				int

             relationType
 { get; set; }
      [JsonProperty("relationTypeName")]
public 				string

             relationTypeName
 { get; set; }
      [JsonProperty("operateType")]
public 				int

             operateType
 { get; set; }
      [JsonProperty("operateTypeName")]
public 				string

             operateTypeName
 { get; set; }
      [JsonProperty("operateRemark")]
public 				string

             operateRemark
 { get; set; }
      [JsonProperty("operatePin")]
public 				string

             operatePin
 { get; set; }
      [JsonProperty("operateName")]
public 				string

             operateName
 { get; set; }
      [JsonProperty("operateDate")]
public 				DateTime

             operateDate
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
