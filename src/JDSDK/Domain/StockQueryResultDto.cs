using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockQueryResultDto:JdObject{
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("orderBookingNum")]
public 				int

             orderBookingNum
 { get; set; }
      [JsonProperty("wname")]
public 				string

             wname
 { get; set; }
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
	}
}
