using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockInfo:JdObject{
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("orderBookingNum")]
public 				int

             orderBookingNum
 { get; set; }
	}
}
