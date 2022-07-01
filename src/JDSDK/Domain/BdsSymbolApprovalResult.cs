using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BdsSymbolApprovalResult:JdObject{
      [JsonProperty("approvalStatus")]
public 				string

             approvalStatus
 { get; set; }
      [JsonProperty("symbolId")]
public 				long

             symbolId
 { get; set; }
      [JsonProperty("qualifyUrl")]
public 				List<string>

             qualifyUrl
 { get; set; }
      [JsonProperty("firstClassifyName")]
public 				string

             firstClassifyName
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("relationId")]
public 				long

             relationId
 { get; set; }
      [JsonProperty("secondClassifyId")]
public 				long

             secondClassifyId
 { get; set; }
      [JsonProperty("secondClassifyName")]
public 				string

             secondClassifyName
 { get; set; }
      [JsonProperty("qualifyEndDate")]
public 				DateTime

             qualifyEndDate
 { get; set; }
      [JsonProperty("firstClassifyId")]
public 				long

             firstClassifyId
 { get; set; }
      [JsonProperty("symbolName")]
public 				string

             symbolName
 { get; set; }
      [JsonProperty("spuId")]
public 				string

             spuId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
	}
}
