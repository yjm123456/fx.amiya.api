using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderShopCategory:JdObject{
      [JsonProperty("cid")]
public 				long

             cid
 { get; set; }
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("shop_id")]
public 				long

                                                                                     shopId
 { get; set; }
      [JsonProperty("parent_cid")]
public 				long

                                                                                     parentCid
 { get; set; }
      [JsonProperty("order_no")]
public 				int

                                                                                     orderNo
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("is_open")]
public 				bool

                                                                                     isOpen
 { get; set; }
      [JsonProperty("is_home_show")]
public 				bool

                                                                                                                     isHomeShow
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("create_time")]
public 				DateTime

                                                                                     createTime
 { get; set; }
      [JsonProperty("modify_time")]
public 				DateTime

                                                                                     modifyTime
 { get; set; }
	}
}
