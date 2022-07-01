using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JOSDetailResultDto:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("delivery_time")]
public 				DateTime

                                                                                     deliveryTime
 { get; set; }
      [JsonProperty("record_count")]
public 				int

                                                                                     recordCount
 { get; set; }
      [JsonProperty("purchase_allocation_detail_list")]
public 				List<string>

                                                                                                                                                     purchaseAllocationDetailList
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("result_code")]
public 				string

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
	}
}
