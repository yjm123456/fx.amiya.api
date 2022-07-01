using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PromoListResultDto:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("result_code")]
public 				int

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
      [JsonProperty("record_count")]
public 				long

                                                                                     recordCount
 { get; set; }
      [JsonProperty("promo_list")]
public 				List<string>

                                                                                     promoList
 { get; set; }
	}
}
