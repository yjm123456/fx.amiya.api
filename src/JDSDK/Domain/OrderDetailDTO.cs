using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDetailDTO:JdObject{
      [JsonProperty("order_sn")]
public 				string

                                                                                     orderSn
 { get; set; }
      [JsonProperty("order_type")]
public 				int

                                                                                     orderType
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("gtm_create")]
public 				DateTime

                                                                                     gtmCreate
 { get; set; }
      [JsonProperty("province_id")]
public 				string

                                                                                     provinceId
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city_id")]
public 				string

                                                                                     cityId
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("district_id")]
public 				string

                                                                                     districtId
 { get; set; }
      [JsonProperty("district")]
public 				string

             district
 { get; set; }
      [JsonProperty("street_id")]
public 				string

                                                                                     streetId
 { get; set; }
      [JsonProperty("street")]
public 				string

             street
 { get; set; }
      [JsonProperty("customer")]
public 				string

             customer
 { get; set; }
      [JsonProperty("receiver")]
public 				string

             receiver
 { get; set; }
      [JsonProperty("receiver_mobile")]
public 				string

                                                                                     receiverMobile
 { get; set; }
      [JsonProperty("receiver_address")]
public 				string

                                                                                     receiverAddress
 { get; set; }
      [JsonProperty("pay_type")]
public 				int

                                                                                     payType
 { get; set; }
      [JsonProperty("ship_type")]
public 				int

                                                                                     shipType
 { get; set; }
      [JsonProperty("is_invoice")]
public 				string

                                                                                     isInvoice
 { get; set; }
      [JsonProperty("shippingfee_direction")]
public 				string

                                                                                     shippingfeeDirection
 { get; set; }
      [JsonProperty("offer_sn")]
public 				string

                                                                                     offerSn
 { get; set; }
      [JsonProperty("demand_sn")]
public 				string

                                                                                     demandSn
 { get; set; }
      [JsonProperty("product_amount")]
public 					string

                                                                                     productAmount
 { get; set; }
      [JsonProperty("total_freight")]
public 					string

                                                                                     totalFreight
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("customer_id")]
public 				int

                                                                                     customerId
 { get; set; }
      [JsonProperty("product_detail")]
public 				List<string>

                                                                                     productDetail
 { get; set; }
	}
}
