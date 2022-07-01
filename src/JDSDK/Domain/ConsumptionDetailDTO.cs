using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConsumptionDetailDTO:JdObject{
      [JsonProperty("quantity")]
public 				int

             quantity
 { get; set; }
      [JsonProperty("user_pin")]
public 				string

                                                                                     userPin
 { get; set; }
      [JsonProperty("face_value")]
public 				string

                                                                                     faceValue
 { get; set; }
      [JsonProperty("type_id")]
public 				long

                                                                                     typeId
 { get; set; }
      [JsonProperty("consumption_id")]
public 				long

                                                                                     consumptionId
 { get; set; }
      [JsonProperty("request_id")]
public 				string

                                                                                     requestId
 { get; set; }
      [JsonProperty("send_date")]
public 				DateTime

                                                                                     sendDate
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("status_desc")]
public 				string

                                                                                     statusDesc
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("type_name")]
public 				string

                                                                                     typeName
 { get; set; }
      [JsonProperty("unit")]
public 				string

             unit
 { get; set; }
      [JsonProperty("amount")]
public 				long

             amount
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
