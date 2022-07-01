using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SettleBill:JdObject{
      [JsonProperty("stat")]
public 				int

             stat
 { get; set; }
      [JsonProperty("settlePeriod")]
public 				string

             settlePeriod
 { get; set; }
      [JsonProperty("repeatProcess")]
public 				int

             repeatProcess
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("settleAmount")]
public 				string

             settleAmount
 { get; set; }
      [JsonProperty("adjustAmount")]
public 				string

             adjustAmount
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("itemCatName")]
public 				string

             itemCatName
 { get; set; }
      [JsonProperty("settle_no")]
public 				string

                                                                                     settleNo
 { get; set; }
      [JsonProperty("settleRate")]
public 				string

             settleRate
 { get; set; }
      [JsonProperty("taxRate")]
public 				string

             taxRate
 { get; set; }
      [JsonProperty("adjustRemark")]
public 				string

             adjustRemark
 { get; set; }
      [JsonProperty("payAmount")]
public 				string

             payAmount
 { get; set; }
      [JsonProperty("serviceTypeName")]
public 				string

             serviceTypeName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
	}
}
