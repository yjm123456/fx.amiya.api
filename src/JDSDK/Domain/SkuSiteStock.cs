using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuSiteStock:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("siteId")]
public 				int

             siteId
 { get; set; }
      [JsonProperty("venderSource")]
public 				string

             venderSource
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("orderBookingNum")]
public 				int

             orderBookingNum
 { get; set; }
      [JsonProperty("appBookingNum")]
public 				int

             appBookingNum
 { get; set; }
      [JsonProperty("canUsedNum")]
public 				int

             canUsedNum
 { get; set; }
	}
}
