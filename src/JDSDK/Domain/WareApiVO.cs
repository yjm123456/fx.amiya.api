using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareApiVO:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("categoryId")]
public 				int

             categoryId
 { get; set; }
      [JsonProperty("wareStatus")]
public 				int

             wareStatus
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
      [JsonProperty("transportId")]
public 				long

             transportId
 { get; set; }
      [JsonProperty("onlineTime")]
public 				DateTime

             onlineTime
 { get; set; }
      [JsonProperty("offlineTime")]
public 				DateTime

             offlineTime
 { get; set; }
      [JsonProperty("attributes")]
public 				string

             attributes
 { get; set; }
      [JsonProperty("minSupplyPrice")]
public 					string

             minSupplyPrice
 { get; set; }
      [JsonProperty("maxSupplyPrice")]
public 					string

             maxSupplyPrice
 { get; set; }
      [JsonProperty("stock")]
public 				int

             stock
 { get; set; }
      [JsonProperty("imgUri")]
public 				string

             imgUri
 { get; set; }
      [JsonProperty("hsCode")]
public 				string

             hsCode
 { get; set; }
      [JsonProperty("recommendTpid")]
public 				int

             recommendTpid
 { get; set; }
      [JsonProperty("customTpid")]
public 				int

             customTpid
 { get; set; }
      [JsonProperty("brandId")]
public 				int

             brandId
 { get; set; }
      [JsonProperty("deliveryDays")]
public 				int

             deliveryDays
 { get; set; }
      [JsonProperty("keywords")]
public 				string

             keywords
 { get; set; }
      [JsonProperty("description")]
public 				string

             description
 { get; set; }
      [JsonProperty("cubage")]
public 				string

             cubage
 { get; set; }
      [JsonProperty("packInfo")]
public 				string

             packInfo
 { get; set; }
      [JsonProperty("netWeight")]
public 				float

             netWeight
 { get; set; }
      [JsonProperty("weight")]
public 				float

             weight
 { get; set; }
      [JsonProperty("packLong")]
public 				float

             packLong
 { get; set; }
      [JsonProperty("packWide")]
public 				float

             packWide
 { get; set; }
      [JsonProperty("packHeight")]
public 				float

             packHeight
 { get; set; }
      [JsonProperty("wareSkus")]
public 				WareSkuApiVO[]

             wareSkus
 { get; set; }
      [JsonProperty("messegeCode")]
public 				string

             messegeCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
