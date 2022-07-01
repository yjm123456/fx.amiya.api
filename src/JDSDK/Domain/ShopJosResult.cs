using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopJosResult:JdObject{
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("shop_id")]
public 				long

                                                                                     shopId
 { get; set; }
      [JsonProperty("shop_name")]
public 				string

                                                                                     shopName
 { get; set; }
      [JsonProperty("open_time")]
public 				DateTime

                                                                                     openTime
 { get; set; }
      [JsonProperty("logo_url")]
public 				string

                                                                                     logoUrl
 { get; set; }
      [JsonProperty("brief")]
public 				string

             brief
 { get; set; }
      [JsonProperty("category_main")]
public 				long

                                                                                     categoryMain
 { get; set; }
      [JsonProperty("category_main_name")]
public 				string

                                                                                                                     categoryMainName
 { get; set; }
	}
}
