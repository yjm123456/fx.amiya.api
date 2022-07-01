using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderModeVO:JdObject{
      [JsonProperty("promo_id")]
public 				long

                                                                                     promoId
 { get; set; }
      [JsonProperty("favor_mode")]
public 				int

                                                                                     favorMode
 { get; set; }
      [JsonProperty("quota")]
public 					string

             quota
 { get; set; }
      [JsonProperty("rate")]
public 					string

             rate
 { get; set; }
      [JsonProperty("plus")]
public 					string

             plus
 { get; set; }
      [JsonProperty("minus")]
public 					string

             minus
 { get; set; }
      [JsonProperty("link")]
public 				string

             link
 { get; set; }
	}
}
