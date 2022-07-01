using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderResp:JdObject{
      [JsonProperty("ENO")]
public 				string

             ENO
 { get; set; }
      [JsonProperty("orderPlatform")]
public 				int

             orderPlatform
 { get; set; }
      [JsonProperty("orderSource")]
public 				int

             orderSource
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("clientId")]
public 				string

             clientId
 { get; set; }
      [JsonProperty("orderChannel")]
public 				int

             orderChannel
 { get; set; }
      [JsonProperty("jdOrderId")]
public 				long

             jdOrderId
 { get; set; }
      [JsonProperty("thirdOrderId")]
public 				string

             thirdOrderId
 { get; set; }
      [JsonProperty("parentJdOrderId")]
public 				long

             parentJdOrderId
 { get; set; }
      [JsonProperty("orderAmount")]
public 					string

             orderAmount
 { get; set; }
      [JsonProperty("orderNeedMoney")]
public 					string

             orderNeedMoney
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTier")]
public 				int

             orderTier
 { get; set; }
      [JsonProperty("deliverState")]
public 				int

             deliverState
 { get; set; }
      [JsonProperty("orderState")]
public 				int

             orderState
 { get; set; }
      [JsonProperty("jdOrderState")]
public 				int

             jdOrderState
 { get; set; }
      [JsonProperty("priceType")]
public 				int

             priceType
 { get; set; }
      [JsonProperty("orderBizType")]
public 				int

             orderBizType
 { get; set; }
      [JsonProperty("confirmState")]
public 				int

             confirmState
 { get; set; }
      [JsonProperty("submitFlag")]
public 				int

             submitFlag
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("orderguid")]
public 				string

             orderguid
 { get; set; }
      [JsonProperty("customerIP")]
public 				string

             customerIP
 { get; set; }
      [JsonProperty("createOrderTime")]
public 				DateTime

             createOrderTime
 { get; set; }
      [JsonProperty("submitOrderTime")]
public 				DateTime

             submitOrderTime
 { get; set; }
      [JsonProperty("outTime")]
public 				DateTime

             outTime
 { get; set; }
      [JsonProperty("arriveTime")]
public 				DateTime

             arriveTime
 { get; set; }
      [JsonProperty("completeTime")]
public 				DateTime

             completeTime
 { get; set; }
      [JsonProperty("accountCheckingTime")]
public 				DateTime

             accountCheckingTime
 { get; set; }
      [JsonProperty("cancelTime")]
public 				DateTime

             cancelTime
 { get; set; }
      [JsonProperty("canceledRemark")]
public 				string

             canceledRemark
 { get; set; }
      [JsonProperty("confirmedBy")]
public 				int

             confirmedBy
 { get; set; }
      [JsonProperty("freight")]
public 					string

             freight
 { get; set; }
      [JsonProperty("jdFreight")]
public 					string

             jdFreight
 { get; set; }
      [JsonProperty("cetusOrgId")]
public 				string

             cetusOrgId
 { get; set; }
      [JsonProperty("trackUpdateTime")]
public 				DateTime

             trackUpdateTime
 { get; set; }
      [JsonProperty("cetusIndustryId")]
public 				int

             cetusIndustryId
 { get; set; }
      [JsonProperty("serviceRate")]
public 					string

             serviceRate
 { get; set; }
      [JsonProperty("lotteryId")]
public 				long

             lotteryId
 { get; set; }
      [JsonProperty("lotteryContacts")]
public 				string

             lotteryContacts
 { get; set; }
      [JsonProperty("jdOrderStateChangetime")]
public 				DateTime

             jdOrderStateChangetime
 { get; set; }
      [JsonProperty("orderIndustry")]
public 				int

             orderIndustry
 { get; set; }
      [JsonProperty("orgId")]
public 				int

             orgId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("extAttr")]
public 					Dictionary<string, object>

             extAttr
 { get; set; }
      [JsonProperty("orderConsignee")]
public 				OrderConsigneeResp

             orderConsignee
 { get; set; }
      [JsonProperty("orderInvoice")]
public 				OrderInvoiceResp

             orderInvoice
 { get; set; }
      [JsonProperty("orderShipment")]
public 				OrderShipmentResp

             orderShipment
 { get; set; }
      [JsonProperty("orderPayment")]
public 				OrderPaymentResp

             orderPayment
 { get; set; }
      [JsonProperty("orderSuits")]
public 				List<string>

             orderSuits
 { get; set; }
      [JsonProperty("orderSkus")]
public 				List<string>

             orderSkus
 { get; set; }
      [JsonProperty("snapshots")]
public 				List<string>

             snapshots
 { get; set; }
      [JsonProperty("orderExtInfoResp")]
public 				OrderExtInfoResp

             orderExtInfoResp
 { get; set; }
	}
}
