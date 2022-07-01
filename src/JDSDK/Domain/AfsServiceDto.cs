using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceDto:JdObject{
      [JsonProperty("customer_order_id")]
public 				string

                                                                                                                     customerOrderId
 { get; set; }
      [JsonProperty("customer_station_no")]
public 				string

                                                                                                                     customerStationNo
 { get; set; }
      [JsonProperty("customer_order_apply_time")]
public 				string

                                                                                                                                                     customerOrderApplyTime
 { get; set; }
      [JsonProperty("customer_order_verify_time")]
public 				string

                                                                                                                                                     customerOrderVerifyTime
 { get; set; }
      [JsonProperty("customer_order_finish_time")]
public 				string

                                                                                                                                                     customerOrderFinishTime
 { get; set; }
      [JsonProperty("customer_order_state")]
public 				string

                                                                                                                     customerOrderState
 { get; set; }
      [JsonProperty("customer_order_type")]
public 				string

                                                                                                                     customerOrderType
 { get; set; }
      [JsonProperty("customer_order_cert")]
public 				string

                                                                                                                     customerOrderCert
 { get; set; }
      [JsonProperty("customer_order_problem")]
public 				string

                                                                                                                     customerOrderProblem
 { get; set; }
      [JsonProperty("customer_order_return_way")]
public 				string

                                                                                                                                                     customerOrderReturnWay
 { get; set; }
      [JsonProperty("customer_order_contactor")]
public 				string

                                                                                                                     customerOrderContactor
 { get; set; }
      [JsonProperty("customer_order_contactor_tel")]
public 				string

                                                                                                                                                     customerOrderContactorTel
 { get; set; }
      [JsonProperty("customer_order_verify_remark")]
public 				string

                                                                                                                                                     customerOrderVerifyRemark
 { get; set; }
      [JsonProperty("order_id")]
public 				string

                                                                                     orderId
 { get; set; }
      [JsonProperty("vender_id")]
public 				string

                                                                                     venderId
 { get; set; }
      [JsonProperty("pay_type")]
public 				string

                                                                                     payType
 { get; set; }
      [JsonProperty("cash_refund")]
public 				string

                                                                                     cashRefund
 { get; set; }
      [JsonProperty("pos_refund")]
public 				string

                                                                                     posRefund
 { get; set; }
      [JsonProperty("pin_buyer")]
public 				string

                                                                                     pinBuyer
 { get; set; }
      [JsonProperty("customer_order_detail_list")]
public 				List<string>

                                                                                                                                                     customerOrderDetailList
 { get; set; }
      [JsonProperty("refund_list")]
public 				List<string>

                                                                                     refundList
 { get; set; }
	}
}
