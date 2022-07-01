using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderinfoResponse:JdObject{
      [JsonProperty("order_id")]
public 				string

                                                                                     orderId
 { get; set; }
      [JsonProperty("vender_id")]
public 				string

                                                                                     venderId
 { get; set; }
      [JsonProperty("pay_type")]
public 				byte

                                                                                     payType
 { get; set; }
      [JsonProperty("sorting_type")]
public 				int

                                                                                     sortingType
 { get; set; }
      [JsonProperty("order_stock_owner")]
public 				string

                                                                                                                     orderStockOwner
 { get; set; }
      [JsonProperty("order_total_price")]
public 				double

                                                                                                                     orderTotalPrice
 { get; set; }
      [JsonProperty("order_payment")]
public 				double

                                                                                     orderPayment
 { get; set; }
      [JsonProperty("order_seller_price")]
public 				double

                                                                                                                     orderSellerPrice
 { get; set; }
      [JsonProperty("freight_price")]
public 				double

                                                                                     freightPrice
 { get; set; }
      [JsonProperty("seller_discount")]
public 				double

                                                                                     sellerDiscount
 { get; set; }
      [JsonProperty("pin_buyer")]
public 				string

                                                                                     pinBuyer
 { get; set; }
      [JsonProperty("delivery_type")]
public 				byte

                                                                                     deliveryType
 { get; set; }
      [JsonProperty("order_type")]
public 				byte

                                                                                     orderType
 { get; set; }
      [JsonProperty("invoice_state")]
public 				string

                                                                                     invoiceState
 { get; set; }
      [JsonProperty("invoice_info")]
public 				string

                                                                                     invoiceInfo
 { get; set; }
      [JsonProperty("order_remark")]
public 				string

                                                                                     orderRemark
 { get; set; }
      [JsonProperty("order_start_time")]
public 				DateTime

                                                                                                                     orderStartTime
 { get; set; }
      [JsonProperty("order_end_time")]
public 				DateTime

                                                                                                                     orderEndTime
 { get; set; }
      [JsonProperty("full_name")]
public 				string

                                                                                     fullName
 { get; set; }
      [JsonProperty("full_address")]
public 				string

                                                                                     fullAddress
 { get; set; }
      [JsonProperty("telephone")]
public 				string

             telephone
 { get; set; }
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("province")]
public 				int

             province
 { get; set; }
      [JsonProperty("city")]
public 				int

             city
 { get; set; }
      [JsonProperty("county")]
public 				int

             county
 { get; set; }
      [JsonProperty("town")]
public 				int

             town
 { get; set; }
      [JsonProperty("province_name")]
public 				string

                                                                                     provinceName
 { get; set; }
      [JsonProperty("city_name")]
public 				string

                                                                                     cityName
 { get; set; }
      [JsonProperty("county_name")]
public 				string

                                                                                     countyName
 { get; set; }
      [JsonProperty("town_name")]
public 				string

                                                                                     townName
 { get; set; }
      [JsonProperty("item_info_list")]
public 				List<string>

                                                                                                                     itemInfoList
 { get; set; }
      [JsonProperty("coupon_detail_list")]
public 				List<string>

                                                                                                                     couponDetailList
 { get; set; }
      [JsonProperty("order_state_list")]
public 				List<string>

                                                                                                                     orderStateList
 { get; set; }
      [JsonProperty("return_order")]
public 				string

                                                                                     returnOrder
 { get; set; }
      [JsonProperty("vender_remark")]
public 				string

                                                                                     venderRemark
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("station_order_state")]
public 				byte

                                                                                                                     stationOrderState
 { get; set; }
      [JsonProperty("station_order_update_time")]
public 				DateTime

                                                                                                                                                     stationOrderUpdateTime
 { get; set; }
      [JsonProperty("station_no")]
public 				string

                                                                                     stationNo
 { get; set; }
      [JsonProperty("station_no_isv")]
public 				string

                                                                                                                     stationNoIsv
 { get; set; }
      [JsonProperty("station_name")]
public 				string

                                                                                     stationName
 { get; set; }
      [JsonProperty("station_order_type")]
public 				byte

                                                                                                                     stationOrderType
 { get; set; }
      [JsonProperty("order_cancel_time")]
public 				DateTime

                                                                                                                     orderCancelTime
 { get; set; }
      [JsonProperty("order_cancel_reason")]
public 				byte

                                                                                                                     orderCancelReason
 { get; set; }
      [JsonProperty("order_backward_remark")]
public 				string

                                                                                                                     orderBackwardRemark
 { get; set; }
      [JsonProperty("station_payment_type")]
public 				byte

                                                                                                                     stationPaymentType
 { get; set; }
      [JsonProperty("station_payment_cash")]
public 				double

                                                                                                                     stationPaymentCash
 { get; set; }
      [JsonProperty("station_payment_pos")]
public 				double

                                                                                                                     stationPaymentPos
 { get; set; }
      [JsonProperty("station_delivery_type")]
public 				byte

                                                                                                                     stationDeliveryType
 { get; set; }
      [JsonProperty("carrier_no")]
public 				string

                                                                                     carrierNo
 { get; set; }
      [JsonProperty("carrier_name")]
public 				string

                                                                                     carrierName
 { get; set; }
      [JsonProperty("deliver_no")]
public 				string

                                                                                     deliverNo
 { get; set; }
	}
}
