using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VatInvoiceResp:JdObject{
      [JsonProperty("taxPayerId")]
public 				string

             taxPayerId
 { get; set; }
      [JsonProperty("regCompanyName")]
public 				string

             regCompanyName
 { get; set; }
      [JsonProperty("regAddress")]
public 				string

             regAddress
 { get; set; }
      [JsonProperty("regPhone")]
public 				string

             regPhone
 { get; set; }
      [JsonProperty("regBank")]
public 				string

             regBank
 { get; set; }
      [JsonProperty("regBankAccount")]
public 				string

             regBankAccount
 { get; set; }
	}
}
