using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ActivityModeVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("promo_id")]
public 				long

                                                                                     promoId
 { get; set; }
      [JsonProperty("num_bound")]
public 				int

                                                                                     numBound
 { get; set; }
      [JsonProperty("freq_bound")]
public 				int

                                                                                     freqBound
 { get; set; }
      [JsonProperty("per_max_num")]
public 				int

                                                                                                                     perMaxNum
 { get; set; }
      [JsonProperty("per_min_num")]
public 				int

                                                                                                                     perMinNum
 { get; set; }
	}
}
