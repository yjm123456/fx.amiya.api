using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderInfoResult:JdObject{
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("col_type")]
public 				int

                                                                                     colType
 { get; set; }
      [JsonProperty("shop_id")]
public 				long

                                                                                     shopId
 { get; set; }
      [JsonProperty("shop_name")]
public 				string

                                                                                     shopName
 { get; set; }
      [JsonProperty("cate_main")]
public 				long

                                                                                     cateMain
 { get; set; }
	}
}
