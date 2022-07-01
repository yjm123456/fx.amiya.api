using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductApplyDto:JdObject{
      [JsonProperty("apply_id")]
public 				string

                                                                                     applyId
 { get; set; }
      [JsonProperty("created_by")]
public 				string

                                                                                     createdBy
 { get; set; }
      [JsonProperty("created_time")]
public 				DateTime

                                                                                     createdTime
 { get; set; }
      [JsonProperty("modified_by")]
public 				string

                                                                                     modifiedBy
 { get; set; }
      [JsonProperty("modified_time")]
public 				DateTime

                                                                                     modifiedTime
 { get; set; }
      [JsonProperty("apply_time")]
public 				DateTime

                                                                                     applyTime
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("archive_status")]
public 				int

                                                                                     archiveStatus
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("product_type")]
public 				int

                                                                                     productType
 { get; set; }
      [JsonProperty("product_info")]
public 				ProductInfoDto

                                                                                     productInfo
 { get; set; }
      [JsonProperty("current_audit_info")]
public 				AuditInfoDto

                                                                                                                     currentAuditInfo
 { get; set; }
      [JsonProperty("audit_records")]
public 				List<string>

                                                                                     auditRecords
 { get; set; }
	}
}
