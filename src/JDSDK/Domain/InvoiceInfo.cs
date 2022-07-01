using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceInfo:JdObject{
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("invoiceState")]
public 				string

             invoiceState
 { get; set; }
      [JsonProperty("invoiceStateName")]
public 				string

             invoiceStateName
 { get; set; }
      [JsonProperty("invoiceLogList")]
public 				List<string>

             invoiceLogList
 { get; set; }
      [JsonProperty("afsAddress")]
public 				AfsAddressInfo

             afsAddress
 { get; set; }
	}
}
