using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SvcApiBooking:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("storeName")]
public 				string

             storeName
 { get; set; }
      [JsonProperty("lcnNo")]
public 				string

             lcnNo
 { get; set; }
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("verificationCode")]
public 				string

             verificationCode
 { get; set; }
      [JsonProperty("bookingTime")]
public 				DateTime

             bookingTime
 { get; set; }
      [JsonProperty("receiveGoodsTime")]
public 				DateTime

             receiveGoodsTime
 { get; set; }
      [JsonProperty("verificationTime")]
public 				DateTime

             verificationTime
 { get; set; }
      [JsonProperty("submitTime")]
public 				DateTime

             submitTime
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("receiveStatus")]
public 				int

             receiveStatus
 { get; set; }
      [JsonProperty("verificationStatus")]
public 				int

             verificationStatus
 { get; set; }
      [JsonProperty("cardOrderId")]
public 				long

             cardOrderId
 { get; set; }
      [JsonProperty("configInfoMap")]
public 					Dictionary<string, object>

             configInfoMap
 { get; set; }
      [JsonProperty("serviceSkuId")]
public 				long

             serviceSkuId
 { get; set; }
      [JsonProperty("serviceSkuName")]
public 				string

             serviceSkuName
 { get; set; }
	}
}
