using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceOut:JdObject{
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("afsCategoryId")]
public 				int

             afsCategoryId
 { get; set; }
      [JsonProperty("afsApplyId")]
public 				int

             afsApplyId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderRemark")]
public 				string

             orderRemark
 { get; set; }
      [JsonProperty("wareId")]
public 				int

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("pickwareProvince")]
public 				int

             pickwareProvince
 { get; set; }
      [JsonProperty("pickwareCity")]
public 				int

             pickwareCity
 { get; set; }
      [JsonProperty("pickwareCounty")]
public 				int

             pickwareCounty
 { get; set; }
      [JsonProperty("pickwareVillage")]
public 				int

             pickwareVillage
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("returnwareProvince")]
public 				int

             returnwareProvince
 { get; set; }
      [JsonProperty("returnwareCity")]
public 				int

             returnwareCity
 { get; set; }
      [JsonProperty("returnwareCounty")]
public 				int

             returnwareCounty
 { get; set; }
      [JsonProperty("returnwareVillage")]
public 				int

             returnwareVillage
 { get; set; }
      [JsonProperty("returnwareAddress")]
public 				string

             returnwareAddress
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
      [JsonProperty("questionDesc")]
public 				string

             questionDesc
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("customerEmail")]
public 				string

             customerEmail
 { get; set; }
      [JsonProperty("approveName")]
public 				string

             approveName
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("approvedDate")]
public 				DateTime

             approvedDate
 { get; set; }
      [JsonProperty("processedDate")]
public 				DateTime

             processedDate
 { get; set; }
      [JsonProperty("receiveDate")]
public 				DateTime

             receiveDate
 { get; set; }
      [JsonProperty("createName")]
public 				string

             createName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
	}
}
