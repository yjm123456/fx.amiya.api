using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderBillStatementVo:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("bid")]
public 				long

             bid
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("billType")]
public 				string

             billType
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("refRefundBillId")]
public 				string

             refRefundBillId
 { get; set; }
      [JsonProperty("businessBillId")]
public 				string

             businessBillId
 { get; set; }
      [JsonProperty("refOrderId")]
public 				string

             refOrderId
 { get; set; }
      [JsonProperty("happenTime")]
public 				DateTime

             happenTime
 { get; set; }
      [JsonProperty("orderCompleteTime")]
public 				DateTime

             orderCompleteTime
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("refStoreId")]
public 				string

             refStoreId
 { get; set; }
      [JsonProperty("storeName")]
public 				string

             storeName
 { get; set; }
      [JsonProperty("orderAmount")]
public 					string

             orderAmount
 { get; set; }
      [JsonProperty("refundAmount")]
public 					string

             refundAmount
 { get; set; }
      [JsonProperty("discountAmount")]
public 					string

             discountAmount
 { get; set; }
      [JsonProperty("usedCouponNum")]
public 				int[]

             usedCouponNum
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("commCharge")]
public 					string

             commCharge
 { get; set; }
      [JsonProperty("couponAmount")]
public 					string

             couponAmount
 { get; set; }
      [JsonProperty("couponNum")]
public 				int[]

             couponNum
 { get; set; }
      [JsonProperty("settleStatus")]
public 				string

             settleStatus
 { get; set; }
	}
}
