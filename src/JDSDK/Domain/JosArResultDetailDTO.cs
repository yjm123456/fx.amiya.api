using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosArResultDetailDTO:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("payableAccountId")]
public 				string

             payableAccountId
 { get; set; }
      [JsonProperty("billType")]
public 				string

             billType
 { get; set; }
      [JsonProperty("billNo")]
public 				string

             billNo
 { get; set; }
      [JsonProperty("poNo")]
public 				string

             poNo
 { get; set; }
      [JsonProperty("relatedPoNo")]
public 				string

             relatedPoNo
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("billDate")]
public 				DateTime

             billDate
 { get; set; }
      [JsonProperty("spCreateTime")]
public 				DateTime

             spCreateTime
 { get; set; }
      [JsonProperty("purchaserName")]
public 				string

             purchaserName
 { get; set; }
      [JsonProperty("salerName")]
public 				string

             salerName
 { get; set; }
      [JsonProperty("dept")]
public 				string

             dept
 { get; set; }
      [JsonProperty("groupName")]
public 				string

             groupName
 { get; set; }
      [JsonProperty("accountPeriodDate")]
public 				DateTime

             accountPeriodDate
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
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("spareCode")]
public 				string

             spareCode
 { get; set; }
	}
}
