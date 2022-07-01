using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SSendpay:JdObject{
      [JsonProperty("signReceiptFlag")]
public 				byte

             signReceiptFlag
 { get; set; }
      [JsonProperty("deliveryReceiptFlag")]
public 				byte

             deliveryReceiptFlag
 { get; set; }
      [JsonProperty("deliveryIntoWarehouse")]
public 				byte

             deliveryIntoWarehouse
 { get; set; }
      [JsonProperty("loadFlag")]
public 				byte

             loadFlag
 { get; set; }
      [JsonProperty("unloadFlag")]
public 				byte

             unloadFlag
 { get; set; }
      [JsonProperty("receiptFlag")]
public 				byte

             receiptFlag
 { get; set; }
      [JsonProperty("fcFlag")]
public 				byte

             fcFlag
 { get; set; }
      [JsonProperty("temporaryStorage")]
public 				byte

             temporaryStorage
 { get; set; }
	}
}
