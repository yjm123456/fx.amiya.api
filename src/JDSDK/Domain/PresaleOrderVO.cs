using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PresaleOrderVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("userPin")]
public 				string

             userPin
 { get; set; }
      [JsonProperty("presaleId")]
public 				long

             presaleId
 { get; set; }
      [JsonProperty("skuID")]
public 				long

             skuID
 { get; set; }
      [JsonProperty("skuCount")]
public 				int

             skuCount
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("shopID")]
public 				long

             shopID
 { get; set; }
      [JsonProperty("freight")]
public 					string

             freight
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("payBargainReal")]
public 					string

             payBargainReal
 { get; set; }
      [JsonProperty("payBargainPlan")]
public 					string

             payBargainPlan
 { get; set; }
      [JsonProperty("bargainTime")]
public 				DateTime

             bargainTime
 { get; set; }
      [JsonProperty("payBalanceReal")]
public 					string

             payBalanceReal
 { get; set; }
      [JsonProperty("payBalancePlan")]
public 					string

             payBalancePlan
 { get; set; }
      [JsonProperty("balanceTime")]
public 				DateTime

             balanceTime
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("orderTime")]
public 				DateTime

             orderTime
 { get; set; }
      [JsonProperty("balanceEndTimePlan")]
public 				DateTime

             balanceEndTimePlan
 { get; set; }
      [JsonProperty("companyid")]
public 				int

             companyid
 { get; set; }
      [JsonProperty("yushouPrice")]
public 					string

             yushouPrice
 { get; set; }
      [JsonProperty("orderPayType")]
public 				int

             orderPayType
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("balanceStartTime")]
public 				DateTime

             balanceStartTime
 { get; set; }
      [JsonProperty("balanceEndTime")]
public 				DateTime

             balanceEndTime
 { get; set; }
	}
}
