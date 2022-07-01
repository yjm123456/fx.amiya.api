using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseAllocationDetailDto:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("deliver_center_id")]
public 				int

                                                                                                                     deliverCenterId
 { get; set; }
      [JsonProperty("deliver_center_name")]
public 				string

                                                                                                                     deliverCenterName
 { get; set; }
      [JsonProperty("ware_name")]
public 				string

                                                                                     wareName
 { get; set; }
      [JsonProperty("purchase_price")]
public 					string

                                                                                     purchasePrice
 { get; set; }
      [JsonProperty("original_num")]
public 				int

                                                                                     originalNum
 { get; set; }
      [JsonProperty("confirm_num")]
public 				int

                                                                                     confirmNum
 { get; set; }
      [JsonProperty("actual_num")]
public 				int

                                                                                     actualNum
 { get; set; }
      [JsonProperty("non_delivery_reason")]
public 				string

                                                                                                                     nonDeliveryReason
 { get; set; }
      [JsonProperty("back_explanation_type")]
public 				int

                                                                                                                     backExplanationType
 { get; set; }
      [JsonProperty("totoal_price")]
public 					string

                                                                                     totoalPrice
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("isbn")]
public 				string

             isbn
 { get; set; }
      [JsonProperty("make_price")]
public 					string

                                                                                     makePrice
 { get; set; }
      [JsonProperty("current_make_price")]
public 					string

                                                                                                                     currentMakePrice
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("store_id")]
public 				int

                                                                                     storeId
 { get; set; }
      [JsonProperty("store_name")]
public 				string

                                                                                     storeName
 { get; set; }
      [JsonProperty("purchase_ware_property")]
public 				PurchaseWarePropertyDto

                                                                                                                     purchaseWareProperty
 { get; set; }
	}
}
