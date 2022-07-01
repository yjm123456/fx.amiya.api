using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReturnBillVo:JdObject{
      [JsonProperty("return_bill_sn")]
public 				string

                                                                                                                     returnBillSn
 { get; set; }
      [JsonProperty("customer_id")]
public 				int

                                                                                     customerId
 { get; set; }
      [JsonProperty("gmt_create")]
public 				string

                                                                                     gmtCreate
 { get; set; }
      [JsonProperty("gmt_modified")]
public 				DateTime

                                                                                     gmtModified
 { get; set; }
      [JsonProperty("modifier_name")]
public 				string

                                                                                     modifierName
 { get; set; }
      [JsonProperty("shipping_fee")]
public 					string

                                                                                     shippingFee
 { get; set; }
      [JsonProperty("shipping_fee_bearer")]
public 				int

                                                                                                                     shippingFeeBearer
 { get; set; }
      [JsonProperty("auditor_name")]
public 				string

                                                                                     auditorName
 { get; set; }
      [JsonProperty("gmt_audit_date")]
public 				DateTime

                                                                                                                     gmtAuditDate
 { get; set; }
      [JsonProperty("unauditor_name")]
public 				string

                                                                                     unauditorName
 { get; set; }
      [JsonProperty("gmt_unaudit_date")]
public 				DateTime

                                                                                                                     gmtUnauditDate
 { get; set; }
      [JsonProperty("bill_status")]
public 				int

                                                                                     billStatus
 { get; set; }
      [JsonProperty("bill_status_name")]
public 				DateTime

                                                                                                                     billStatusName
 { get; set; }
      [JsonProperty("return_amount")]
public 					string

                                                                                     returnAmount
 { get; set; }
      [JsonProperty("order_sn")]
public 				string

                                                                                     orderSn
 { get; set; }
      [JsonProperty("order_type")]
public 				int

                                                                                     orderType
 { get; set; }
      [JsonProperty("order_status")]
public 				string

                                                                                     orderStatus
 { get; set; }
      [JsonProperty("order_status_name")]
public 				string

                                                                                                                     orderStatusName
 { get; set; }
      [JsonProperty("order_amount")]
public 					string

                                                                                     orderAmount
 { get; set; }
      [JsonProperty("province_name")]
public 				string

                                                                                     provinceName
 { get; set; }
      [JsonProperty("city_name")]
public 				string

                                                                                     cityName
 { get; set; }
      [JsonProperty("district_name")]
public 				string

                                                                                     districtName
 { get; set; }
      [JsonProperty("street_name")]
public 				string

                                                                                     streetName
 { get; set; }
      [JsonProperty("customer_name")]
public 				string

                                                                                     customerName
 { get; set; }
      [JsonProperty("customer_phone")]
public 				string

                                                                                     customerPhone
 { get; set; }
      [JsonProperty("return_address")]
public 				string

                                                                                     returnAddress
 { get; set; }
      [JsonProperty("return_reason")]
public 				string

                                                                                     returnReason
 { get; set; }
      [JsonProperty("return_comment")]
public 				string

                                                                                     returnComment
 { get; set; }
      [JsonProperty("unaudit_reason")]
public 				string

                                                                                     unauditReason
 { get; set; }
      [JsonProperty("send_goods_time")]
public 				DateTime

                                                                                                                     sendGoodsTime
 { get; set; }
      [JsonProperty("logistics_company_name")]
public 				string

                                                                                                                     logisticsCompanyName
 { get; set; }
      [JsonProperty("logistics_no")]
public 				string

                                                                                     logisticsNo
 { get; set; }
      [JsonProperty("logistics_remarks")]
public 				string

                                                                                     logisticsRemarks
 { get; set; }
      [JsonProperty("receive_goods_time")]
public 				DateTime

                                                                                                                     receiveGoodsTime
 { get; set; }
      [JsonProperty("auto_sign")]
public 				int

                                                                                     autoSign
 { get; set; }
      [JsonProperty("settle_return_status")]
public 				int

                                                                                                                     settleReturnStatus
 { get; set; }
      [JsonProperty("pay_return_status")]
public 				int

                                                                                                                     payReturnStatus
 { get; set; }
      [JsonProperty("commondity_detail")]
public 				List<string>

                                                                                     commondityDetail
 { get; set; }
	}
}
