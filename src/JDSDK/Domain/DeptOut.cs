using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeptOut:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("sellerNo")]
public 				string

             sellerNo
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("enableTemplate")]
public 				string

             enableTemplate
 { get; set; }
      [JsonProperty("managerName")]
public 				string

             managerName
 { get; set; }
      [JsonProperty("managerPhone")]
public 				string

             managerPhone
 { get; set; }
      [JsonProperty("managerFax")]
public 				string

             managerFax
 { get; set; }
      [JsonProperty("managerEmail")]
public 				string

             managerEmail
 { get; set; }
      [JsonProperty("managerAddress")]
public 				string

             managerAddress
 { get; set; }
      [JsonProperty("settlementMode")]
public 				string

             settlementMode
 { get; set; }
      [JsonProperty("settlementBody")]
public 				string

             settlementBody
 { get; set; }
      [JsonProperty("resultsSection")]
public 				string

             resultsSection
 { get; set; }
      [JsonProperty("accountData")]
public 				string

             accountData
 { get; set; }
      [JsonProperty("qualification")]
public 				string

             qualification
 { get; set; }
      [JsonProperty("billingConditions")]
public 				string

             billingConditions
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("reserve1")]
public 				string

             reserve1
 { get; set; }
      [JsonProperty("reserve2")]
public 				string

             reserve2
 { get; set; }
      [JsonProperty("reserve3")]
public 				string

             reserve3
 { get; set; }
      [JsonProperty("reserve4")]
public 				string

             reserve4
 { get; set; }
      [JsonProperty("reserve5")]
public 				string

             reserve5
 { get; set; }
	}
}
