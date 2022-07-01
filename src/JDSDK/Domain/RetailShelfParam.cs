using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RetailShelfParam:JdObject{
      [JsonProperty("city_id")]
public 				string

                                                                                     cityId
 { get; set; }
      [JsonProperty("shelf_status")]
public 				string

                                                                                     shelfStatus
 { get; set; }
      [JsonProperty("jd_price")]
public 					string

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("yx_Price")]
public 					string

                                                                                     yxPrice
 { get; set; }
	}
}
