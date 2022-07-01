using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MyProductInfoDto:JdObject{
      [JsonProperty("ware_id")]
public 				string

                                                                                     wareId
 { get; set; }
      [JsonProperty("ware_name")]
public 				string

                                                                                     wareName
 { get; set; }
      [JsonProperty("sale_state")]
public 				int

                                                                                     saleState
 { get; set; }
      [JsonProperty("modify_time")]
public 				DateTime

                                                                                     modifyTime
 { get; set; }
      [JsonProperty("is_primary")]
public 				int

                                                                                     isPrimary
 { get; set; }
      [JsonProperty("is_gaea")]
public 				int

                                                                                     isGaea
 { get; set; }
	}
}
