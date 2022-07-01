using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceLog:JdObject{
      [JsonProperty("operatePin")]
public 				string

             operatePin
 { get; set; }
      [JsonProperty("operateDate")]
public 				DateTime

             operateDate
 { get; set; }
      [JsonProperty("operateContent")]
public 				string

             operateContent
 { get; set; }
      [JsonProperty("operateType")]
public 				int

             operateType
 { get; set; }
      [JsonProperty("operateTypeName")]
public 				string

             operateTypeName
 { get; set; }
      [JsonProperty("invoiceState")]
public 				int

             invoiceState
 { get; set; }
      [JsonProperty("invoiceStateName")]
public 				string

             invoiceStateName
 { get; set; }
	}
}
