using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SettleBillDetail:JdObject{
      [JsonProperty("assessAmount")]
public 				string

             assessAmount
 { get; set; }
      [JsonProperty("taxRate")]
public 				string

             taxRate
 { get; set; }
      [JsonProperty("jdCheckDate")]
public 				DateTime

             jdCheckDate
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("amount")]
public 				string

             amount
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("serviceAmount")]
public 				string

             serviceAmount
 { get; set; }
      [JsonProperty("settleItem")]
public 				string

             settleItem
 { get; set; }
      [JsonProperty("assessRemark")]
public 				string

             assessRemark
 { get; set; }
      [JsonProperty("itemCatName")]
public 				string

             itemCatName
 { get; set; }
      [JsonProperty("settleNo")]
public 				string

             settleNo
 { get; set; }
	}
}
