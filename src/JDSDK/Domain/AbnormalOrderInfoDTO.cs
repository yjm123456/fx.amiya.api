using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AbnormalOrderInfoDTO:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
      [JsonProperty("operateTime")]
public 				DateTime

             operateTime
 { get; set; }
      [JsonProperty("mainTypeName")]
public 				string

             mainTypeName
 { get; set; }
      [JsonProperty("reqestComment")]
public 				string

             reqestComment
 { get; set; }
      [JsonProperty("currentAuditCounter")]
public 				int

             currentAuditCounter
 { get; set; }
      [JsonProperty("totalAuditCounter")]
public 				int

             totalAuditCounter
 { get; set; }
	}
}
