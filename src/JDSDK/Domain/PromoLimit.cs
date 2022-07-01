using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PromoLimit:JdObject{
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("category_id")]
public 				long

                                                                                     categoryId
 { get; set; }
      [JsonProperty("discount_limit")]
public 				double

                                                                                     discountLimit
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
