using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DetailResultDto:JdObject{
      [JsonProperty("returnId")]
public 				long

             returnId
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("fromDeliverCenterName")]
public 				string

             fromDeliverCenterName
 { get; set; }
      [JsonProperty("toDeliverCenterName")]
public 				string

             toDeliverCenterName
 { get; set; }
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
      [JsonProperty("totalPrice")]
public 					string

             totalPrice
 { get; set; }
      [JsonProperty("wareVariety")]
public 				int

             wareVariety
 { get; set; }
      [JsonProperty("bookingDate")]
public 				DateTime

             bookingDate
 { get; set; }
      [JsonProperty("deliverTime")]
public 				DateTime

             deliverTime
 { get; set; }
      [JsonProperty("balanceState")]
public 				int

             balanceState
 { get; set; }
      [JsonProperty("balanceStateName")]
public 				string

             balanceStateName
 { get; set; }
      [JsonProperty("balanceDate")]
public 				DateTime

             balanceDate
 { get; set; }
      [JsonProperty("opinion")]
public 				string

             opinion
 { get; set; }
      [JsonProperty("outStoreRoomDate")]
public 				DateTime

             outStoreRoomDate
 { get; set; }
      [JsonProperty("detailDtoList")]
public 				List<string>

             detailDtoList
 { get; set; }
	}
}
