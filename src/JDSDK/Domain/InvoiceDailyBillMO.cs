using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceDailyBillMO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("accountId")]
public 				long

             accountId
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("invoiceAmount")]
public 					string

             invoiceAmount
 { get; set; }
      [JsonProperty("receiveAmount")]
public 					string

             receiveAmount
 { get; set; }
      [JsonProperty("payableAmount")]
public 					string

             payableAmount
 { get; set; }
      [JsonProperty("settleAmount")]
public 					string

             settleAmount
 { get; set; }
      [JsonProperty("invoiceDirection")]
public 				int

             invoiceDirection
 { get; set; }
      [JsonProperty("applyId")]
public 				long

             applyId
 { get; set; }
      [JsonProperty("invoiceOrgName")]
public 				string

             invoiceOrgName
 { get; set; }
      [JsonProperty("billDate")]
public 				DateTime

             billDate
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("companyId")]
public 				long

             companyId
 { get; set; }
      [JsonProperty("invoiceOrg")]
public 				string

             invoiceOrg
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
