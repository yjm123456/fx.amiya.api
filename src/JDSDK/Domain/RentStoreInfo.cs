using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RentStoreInfo:JdObject{
      [JsonProperty("com_id")]
public 				long

                                                                                     comId
 { get; set; }
      [JsonProperty("com_name")]
public 				string

                                                                                     comName
 { get; set; }
      [JsonProperty("org_id")]
public 				long

                                                                                     orgId
 { get; set; }
      [JsonProperty("wh_id")]
public 				long

                                                                                     whId
 { get; set; }
      [JsonProperty("org_name")]
public 				string

                                                                                     orgName
 { get; set; }
      [JsonProperty("wh_name")]
public 				string

                                                                                     whName
 { get; set; }
      [JsonProperty("custom_name")]
public 				string

                                                                                     customName
 { get; set; }
      [JsonProperty("areaRent")]
public 				int[]

             areaRent
 { get; set; }
      [JsonProperty("apply_time")]
public 				DateTime

                                                                                     applyTime
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("contract")]
public 				string

             contract
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("zip_code")]
public 				string

                                                                                     zipCode
 { get; set; }
      [JsonProperty("back_name")]
public 				string

                                                                                     backName
 { get; set; }
      [JsonProperty("back_phone")]
public 				string

                                                                                     backPhone
 { get; set; }
	}
}
