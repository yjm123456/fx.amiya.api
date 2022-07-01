using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSalesOutWarehouseDto:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("serialNo")]
public 				string

             serialNo
 { get; set; }
      [JsonProperty("ckBusId")]
public 				string

             ckBusId
 { get; set; }
      [JsonProperty("saleOrdTm")]
public 				DateTime

             saleOrdTm
 { get; set; }
      [JsonProperty("ckTime")]
public 				DateTime

             ckTime
 { get; set; }
      [JsonProperty("userPayablePayAmount")]
public 				string

             userPayablePayAmount
 { get; set; }
	}
}
