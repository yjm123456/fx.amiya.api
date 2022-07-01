using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShipAddressVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("contact")]
public 				string

             contact
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("zip_code")]
public 				string

                                                                                     zipCode
 { get; set; }
      [JsonProperty("full_address")]
public 				string

                                                                                     fullAddress
 { get; set; }
      [JsonProperty("full_area_id")]
public 				string

                                                                                                                     fullAreaId
 { get; set; }
      [JsonProperty("default_address_flag")]
public 				string

                                                                                                                     defaultAddressFlag
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
