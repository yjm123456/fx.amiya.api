using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDTO:JdObject{
      [JsonProperty("promiseStartTime")]
public 				DateTime

             promiseStartTime
 { get; set; }
      [JsonProperty("promiseType")]
public 				int

             promiseType
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("orderRemark")]
public 				string

             orderRemark
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("promiseEndTime")]
public 				DateTime

             promiseEndTime
 { get; set; }
      [JsonProperty("itemInfo")]
public 				List<string>

             itemInfo
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("orderStateRemark")]
public 				string

             orderStateRemark
 { get; set; }
      [JsonProperty("rxtype")]
public 				int

             rxtype
 { get; set; }
      [JsonProperty("operateRecord")]
public 				List<string>

             operateRecord
 { get; set; }
      [JsonProperty("orderDate")]
public 				DateTime

             orderDate
 { get; set; }
      [JsonProperty("payment")]
public 				PaymentDTO

             payment
 { get; set; }
      [JsonProperty("invoiceInfo")]
public 				InvoiceInfoDTO

             invoiceInfo
 { get; set; }
      [JsonProperty("rxInfo")]
public 				RxInfoDTO

             rxInfo
 { get; set; }
      [JsonProperty("consigneeInfo")]
public 				ConsigneeInfoDTO

             consigneeInfo
 { get; set; }
      [JsonProperty("deliveryStatus")]
public 				int

             deliveryStatus
 { get; set; }
      [JsonProperty("deliveryStatusDesc")]
public 				string

             deliveryStatusDesc
 { get; set; }
      [JsonProperty("waybillNo")]
public 				string

             waybillNo
 { get; set; }
      [JsonProperty("agingType")]
public 				int

             agingType
 { get; set; }
      [JsonProperty("serialNum")]
public 				int

             serialNum
 { get; set; }
      [JsonProperty("distribution")]
public 				int

             distribution
 { get; set; }
	}
}
