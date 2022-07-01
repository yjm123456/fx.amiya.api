using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RoDto:JdObject{
      [JsonProperty("returnId")]
public 				long

             returnId
 { get; set; }
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("fromDeliverCenterName")]
public 				string

             fromDeliverCenterName
 { get; set; }
      [JsonProperty("toDeliverCenterName")]
public 				string

             toDeliverCenterName
 { get; set; }
      [JsonProperty("returnStateName")]
public 				string

             returnStateName
 { get; set; }
      [JsonProperty("totalNum")]
public 				int

             totalNum
 { get; set; }
      [JsonProperty("totalPrice")]
public 					string

             totalPrice
 { get; set; }
      [JsonProperty("stockName")]
public 				string

             stockName
 { get; set; }
      [JsonProperty("wareHouseAddress")]
public 				string

             wareHouseAddress
 { get; set; }
      [JsonProperty("wareHouseCell")]
public 				string

             wareHouseCell
 { get; set; }
      [JsonProperty("wareHouseContact")]
public 				string

             wareHouseContact
 { get; set; }
      [JsonProperty("outStoreRoomDate")]
public 				DateTime

             outStoreRoomDate
 { get; set; }
      [JsonProperty("wareVariety")]
public 				int

             wareVariety
 { get; set; }
      [JsonProperty("balanceStateName")]
public 				string

             balanceStateName
 { get; set; }
      [JsonProperty("balanceDate")]
public 				DateTime

             balanceDate
 { get; set; }
	}
}
