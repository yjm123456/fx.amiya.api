using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSpuExtendInfoDto:JdObject{
      [JsonProperty("advWords")]
public 				string

             advWords
 { get; set; }
      [JsonProperty("advLinkWords")]
public 				string

             advLinkWords
 { get; set; }
      [JsonProperty("advLinkUrl")]
public 				string

             advLinkUrl
 { get; set; }
      [JsonProperty("shopCategorys")]
public 				string

             shopCategorys
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
      [JsonProperty("taxInfo")]
public 				string

             taxInfo
 { get; set; }
      [JsonProperty("isSnManage")]
public 				int

             isSnManage
 { get; set; }
      [JsonProperty("isSafeDayManage")]
public 				int

             isSafeDayManage
 { get; set; }
      [JsonProperty("safeDays")]
public 				string

             safeDays
 { get; set; }
      [JsonProperty("productionTime")]
public 				string

             productionTime
 { get; set; }
      [JsonProperty("warrantyInfo")]
public 				string

             warrantyInfo
 { get; set; }
      [JsonProperty("servicePhone")]
public 				string

             servicePhone
 { get; set; }
      [JsonProperty("site")]
public 				string

             site
 { get; set; }
      [JsonProperty("transportId")]
public 				int

             transportId
 { get; set; }
      [JsonProperty("auditState")]
public 				int

             auditState
 { get; set; }
      [JsonProperty("jdSpuId")]
public 				long

             jdSpuId
 { get; set; }
      [JsonProperty("b2bSpuId")]
public 				long

             b2bSpuId
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
      [JsonProperty("productOwner")]
public 				string

             productOwner
 { get; set; }
      [JsonProperty("productShortTitle")]
public 				string

             productShortTitle
 { get; set; }
	}
}
