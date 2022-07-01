using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDetail:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTotalFee")]
public 				long

             orderTotalFee
 { get; set; }
      [JsonProperty("payStatus")]
public 				int

             payStatus
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("needReceipt")]
public 				bool

             needReceipt
 { get; set; }
      [JsonProperty("productInfoList")]
public 				List<string>

             productInfoList
 { get; set; }
      [JsonProperty("payInfoList")]
public 				List<string>

             payInfoList
 { get; set; }
      [JsonProperty("receiptInfo")]
public 				ReceiptInfo

             receiptInfo
 { get; set; }
      [JsonProperty("addressInfo")]
public 				AddressInfo

             addressInfo
 { get; set; }
      [JsonProperty("payTime")]
public 				DateTime

             payTime
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("features")]
public 					Dictionary<string, object>

             features
 { get; set; }
	}
}
