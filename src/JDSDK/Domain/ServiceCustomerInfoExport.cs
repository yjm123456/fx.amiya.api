using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceCustomerInfoExport:JdObject{
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerContactName")]
public 				string

             customerContactName
 { get; set; }
      [JsonProperty("customerTel")]
public 				string

             customerTel
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("customerEmail")]
public 				string

             customerEmail
 { get; set; }
      [JsonProperty("customerPostcode")]
public 				string

             customerPostcode
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
	}
}
