using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RefundApplyVo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("buyerId")]
public 				string

             buyerId
 { get; set; }
      [JsonProperty("buyerName")]
public 				string

             buyerName
 { get; set; }
      [JsonProperty("checkTime")]
public 				string

             checkTime
 { get; set; }
      [JsonProperty("applyTime")]
public 				string

             applyTime
 { get; set; }
      [JsonProperty("applyRefundSum")]
public 				double

             applyRefundSum
 { get; set; }
      [JsonProperty("status")]
public 				long

             status
 { get; set; }
      [JsonProperty("checkUserName")]
public 				string

             checkUserName
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("checkRemark")]
public 				string

             checkRemark
 { get; set; }
      [JsonProperty("reason")]
public 				string

             reason
 { get; set; }
      [JsonProperty("systemId")]
public 				int

             systemId
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
