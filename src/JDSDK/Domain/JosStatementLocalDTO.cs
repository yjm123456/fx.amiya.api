using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosStatementLocalDTO:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("billNo")]
public 				string

             billNo
 { get; set; }
      [JsonProperty("billTime")]
public 				string

             billTime
 { get; set; }
      [JsonProperty("collectionAmount")]
public 					string

             collectionAmount
 { get; set; }
      [JsonProperty("payAmount")]
public 					string

             payAmount
 { get; set; }
      [JsonProperty("finalAmount")]
public 					string

             finalAmount
 { get; set; }
      [JsonProperty("invoiceAmount")]
public 					string

             invoiceAmount
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateUser")]
public 				string

             updateUser
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
