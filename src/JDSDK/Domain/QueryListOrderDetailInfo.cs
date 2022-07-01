using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryListOrderDetailInfo:JdObject{
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("wareNum")]
public 				int

             wareNum
 { get; set; }
      [JsonProperty("jdPrice")]
public 					string

             jdPrice
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("cost")]
public 					string

             cost
 { get; set; }
      [JsonProperty("poId")]
public 				long

             poId
 { get; set; }
      [JsonProperty("roId")]
public 				long

             roId
 { get; set; }
	}
}
