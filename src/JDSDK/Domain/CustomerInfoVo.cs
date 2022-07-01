using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerInfoVo:JdObject{
      [JsonProperty("mobile")]
public 				string

             mobile
 { get; set; }
      [JsonProperty("customer_name")]
public 				string

                                                                                     customerName
 { get; set; }
      [JsonProperty("account_name")]
public 				string

                                                                                     accountName
 { get; set; }
      [JsonProperty("consignee")]
public 				string

             consignee
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("province_name")]
public 				string

                                                                                     provinceName
 { get; set; }
      [JsonProperty("city_name")]
public 				string

                                                                                     cityName
 { get; set; }
      [JsonProperty("district_name")]
public 				string

                                                                                     districtName
 { get; set; }
      [JsonProperty("street_name")]
public 				string

                                                                                     streetName
 { get; set; }
	}
}
