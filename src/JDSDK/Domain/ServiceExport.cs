using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceExport:JdObject{
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTypeName")]
public 				string

             orderTypeName
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("afsServiceProcessResult")]
public 				int

             afsServiceProcessResult
 { get; set; }
      [JsonProperty("afsServiceProcessResultName")]
public 				string

             afsServiceProcessResultName
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("processName")]
public 				string

             processName
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("processedDate")]
public 				DateTime

             processedDate
 { get; set; }
      [JsonProperty("afsServiceStatus")]
public 				int

             afsServiceStatus
 { get; set; }
      [JsonProperty("afsServiceStatusName")]
public 				string

             afsServiceStatusName
 { get; set; }
      [JsonProperty("afsServiceStep")]
public 				int

             afsServiceStep
 { get; set; }
      [JsonProperty("approveResonCid1")]
public 				int

             approveResonCid1
 { get; set; }
      [JsonProperty("approveResonCid2")]
public 				int

             approveResonCid2
 { get; set; }
      [JsonProperty("wareId")]
public 				int

             wareId
 { get; set; }
      [JsonProperty("approveDate")]
public 				DateTime

             approveDate
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
	}
}
