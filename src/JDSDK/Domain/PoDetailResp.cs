using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoDetailResp:JdObject{
      [JsonProperty("consigneeResp")]
public 				ConsigneeResp

             consigneeResp
 { get; set; }
      [JsonProperty("invoiceResp")]
public 				InvoiceResp

             invoiceResp
 { get; set; }
	}
}
