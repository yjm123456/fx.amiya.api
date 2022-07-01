using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtsResult:JdObject{
      [JsonProperty("eclpRtsNo")]
public 				string

             eclpRtsNo
 { get; set; }
      [JsonProperty("isvRtsNum")]
public 				string

             isvRtsNum
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deliveryMode")]
public 				string

             deliveryMode
 { get; set; }
      [JsonProperty("supplierNo")]
public 				string

             supplierNo
 { get; set; }
      [JsonProperty("rtsOrderStatus")]
public 				string

             rtsOrderStatus
 { get; set; }
      [JsonProperty("operatorTime")]
public 				string

             operatorTime
 { get; set; }
      [JsonProperty("operatorUser")]
public 				string

             operatorUser
 { get; set; }
      [JsonProperty("source")]
public 				string

             source
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("receiver")]
public 				string

             receiver
 { get; set; }
      [JsonProperty("receiverPhone")]
public 				string

             receiverPhone
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("county")]
public 				string

             county
 { get; set; }
      [JsonProperty("town")]
public 				string

             town
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("rtsDetailList")]
public 				List<string>

             rtsDetailList
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("failMsg")]
public 				string

             failMsg
 { get; set; }
	}
}
