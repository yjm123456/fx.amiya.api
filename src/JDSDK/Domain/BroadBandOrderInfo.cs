using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BroadBandOrderInfo:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("sku_name")]
public 				string

                                                                                     skuName
 { get; set; }
      [JsonProperty("sku_price")]
public 					string

                                                                                     skuPrice
 { get; set; }
      [JsonProperty("order_price")]
public 					string

                                                                                     orderPrice
 { get; set; }
      [JsonProperty("broadband_type")]
public 				int

                                                                                     broadbandType
 { get; set; }
      [JsonProperty("broadband_type_desc")]
public 				string

                                                                                                                     broadbandTypeDesc
 { get; set; }
      [JsonProperty("customer_name")]
public 				string

                                                                                     customerName
 { get; set; }
      [JsonProperty("id_number")]
public 				string

                                                                                     idNumber
 { get; set; }
      [JsonProperty("address_detail")]
public 				string

                                                                                     addressDetail
 { get; set; }
      [JsonProperty("broadband_account")]
public 				string

                                                                                     broadbandAccount
 { get; set; }
      [JsonProperty("operator")]
public 				int

             operator1
 { get; set; }
      [JsonProperty("operator_desc")]
public 				string

                                                                                     operatorDesc
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("erp_status")]
public 				int

                                                                                     erpStatus
 { get; set; }
      [JsonProperty("erp_status_desc")]
public 				string

                                                                                                                     erpStatusDesc
 { get; set; }
      [JsonProperty("order_created")]
public 				string

                                                                                     orderCreated
 { get; set; }
      [JsonProperty("county")]
public 				string

             county
 { get; set; }
      [JsonProperty("town")]
public 				string

             town
 { get; set; }
      [JsonProperty("phone_number")]
public 				long

                                                                                     phoneNumber
 { get; set; }
      [JsonProperty("channel_no")]
public 				string

                                                                                     channelNo
 { get; set; }
	}
}
