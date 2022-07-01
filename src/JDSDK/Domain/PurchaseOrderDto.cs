using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseOrderDto:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("created_date")]
public 				DateTime

                                                                                     createdDate
 { get; set; }
      [JsonProperty("provider_code")]
public 				string

                                                                                     providerCode
 { get; set; }
      [JsonProperty("provider_name")]
public 				string

                                                                                     providerName
 { get; set; }
      [JsonProperty("total_price")]
public 					string

                                                                                     totalPrice
 { get; set; }
      [JsonProperty("deliver_center_id")]
public 				int

                                                                                                                     deliverCenterId
 { get; set; }
      [JsonProperty("deliver_center_name")]
public 				string

                                                                                                                     deliverCenterName
 { get; set; }
      [JsonProperty("purchaser_name")]
public 				string

                                                                                     purchaserName
 { get; set; }
      [JsonProperty("purchaser_erp_code")]
public 				string

                                                                                                                     purchaserErpCode
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("status_name")]
public 				string

                                                                                     statusName
 { get; set; }
      [JsonProperty("is_ept_customized")]
public 				bool

                                                                                                                     isEptCustomized
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("state_name")]
public 				string

                                                                                     stateName
 { get; set; }
      [JsonProperty("complete_date")]
public 				DateTime

                                                                                     completeDate
 { get; set; }
      [JsonProperty("update_date")]
public 				DateTime

                                                                                     updateDate
 { get; set; }
      [JsonProperty("account_period")]
public 				int

                                                                                     accountPeriod
 { get; set; }
      [JsonProperty("receiver_name")]
public 				string

                                                                                     receiverName
 { get; set; }
      [JsonProperty("warehouse_phone")]
public 				string

                                                                                     warehousePhone
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("order_type")]
public 				int

                                                                                     orderType
 { get; set; }
      [JsonProperty("order_type_name")]
public 				string

                                                                                                                     orderTypeName
 { get; set; }
      [JsonProperty("order_attribute")]
public 				int

                                                                                     orderAttribute
 { get; set; }
      [JsonProperty("order_attribute_name")]
public 				string

                                                                                                                     orderAttributeName
 { get; set; }
      [JsonProperty("confirm_state")]
public 				int

                                                                                     confirmState
 { get; set; }
      [JsonProperty("confirm_state_name")]
public 				string

                                                                                                                     confirmStateName
 { get; set; }
      [JsonProperty("custom_order_id")]
public 				long

                                                                                                                     customOrderId
 { get; set; }
      [JsonProperty("ware_variety")]
public 				int

                                                                                     wareVariety
 { get; set; }
      [JsonProperty("delivery_time")]
public 				DateTime

                                                                                     deliveryTime
 { get; set; }
      [JsonProperty("is_can_confirm")]
public 				bool

                                                                                                                     isCanConfirm
 { get; set; }
      [JsonProperty("is_exist_actual_num_dif")]
public 				int

                                                                                                                                                                                     isExistActualNumDif
 { get; set; }
      [JsonProperty("balance_status")]
public 				bool

                                                                                     balanceStatus
 { get; set; }
      [JsonProperty("storage_time")]
public 				DateTime

                                                                                     storageTime
 { get; set; }
      [JsonProperty("tc_flag")]
public 				int

                                                                                     tcFlag
 { get; set; }
      [JsonProperty("tc_flag_name")]
public 				string

                                                                                                                     tcFlagName
 { get; set; }
      [JsonProperty("book_time")]
public 				DateTime

                                                                                     bookTime
 { get; set; }
	}
}
