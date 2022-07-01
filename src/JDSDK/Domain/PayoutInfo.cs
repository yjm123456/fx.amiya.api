using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PayoutInfo:JdObject{
      [JsonProperty("payoutId")]
public 				int

             payoutId
 { get; set; }
      [JsonProperty("billType")]
public 					int

             billType
 { get; set; }
      [JsonProperty("billTypeName")]
public 				string

             billTypeName
 { get; set; }
      [JsonProperty("payoutType")]
public 					int

             payoutType
 { get; set; }
      [JsonProperty("payoutTypeName")]
public 				string

             payoutTypeName
 { get; set; }
      [JsonProperty("total")]
public 					string

             total
 { get; set; }
      [JsonProperty("levelIReasonId")]
public 					int

             levelIReasonId
 { get; set; }
      [JsonProperty("levelIReasonName")]
public 				string

             levelIReasonName
 { get; set; }
      [JsonProperty("levelIiReasonId")]
public 					int

             levelIiReasonId
 { get; set; }
      [JsonProperty("levelIiReasonName")]
public 				string

             levelIiReasonName
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("statusName")]
public 				string

             statusName
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
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("arbitId")]
public 				long

             arbitId
 { get; set; }
      [JsonProperty("applyTime")]
public 				DateTime

             applyTime
 { get; set; }
      [JsonProperty("applyPin")]
public 				string

             applyPin
 { get; set; }
      [JsonProperty("applyName")]
public 				string

             applyName
 { get; set; }
      [JsonProperty("applyReason")]
public 				string

             applyReason
 { get; set; }
      [JsonProperty("auditTime")]
public 				DateTime

             auditTime
 { get; set; }
      [JsonProperty("auditPin")]
public 				string

             auditPin
 { get; set; }
      [JsonProperty("auditName")]
public 				string

             auditName
 { get; set; }
      [JsonProperty("auditOpinion")]
public 				string

             auditOpinion
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("responsibleDeptId")]
public 				int

             responsibleDeptId
 { get; set; }
      [JsonProperty("responsibleDeptName")]
public 				string

             responsibleDeptName
 { get; set; }
      [JsonProperty("complainFee")]
public 				bool

             complainFee
 { get; set; }
      [JsonProperty("payoutDetailInfoList")]
public 				List<string>

             payoutDetailInfoList
 { get; set; }
      [JsonProperty("payoutShareInfoList")]
public 				List<string>

             payoutShareInfoList
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
