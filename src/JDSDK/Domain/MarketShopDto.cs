using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MarketShopDto:JdObject{
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("projectId")]
public 				long

             projectId
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("contacts")]
public 				string

             contacts
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("shopAddressProvince")]
public 				long

             shopAddressProvince
 { get; set; }
      [JsonProperty("shopAddressProvinceName")]
public 				string

             shopAddressProvinceName
 { get; set; }
      [JsonProperty("shopAddressCity")]
public 				long

             shopAddressCity
 { get; set; }
      [JsonProperty("shopAddressCityName")]
public 				string

             shopAddressCityName
 { get; set; }
      [JsonProperty("shopAddressCountry")]
public 				long

             shopAddressCountry
 { get; set; }
      [JsonProperty("shopAddressCountryName")]
public 				string

             shopAddressCountryName
 { get; set; }
      [JsonProperty("shopAddressStreet")]
public 				long

             shopAddressStreet
 { get; set; }
      [JsonProperty("shopAddressStreetName")]
public 				string

             shopAddressStreetName
 { get; set; }
      [JsonProperty("shopAddressDetail")]
public 				string

             shopAddressDetail
 { get; set; }
      [JsonProperty("lat")]
public 					string

             lat
 { get; set; }
      [JsonProperty("lng")]
public 					string

             lng
 { get; set; }
      [JsonProperty("merchantName")]
public 				string

             merchantName
 { get; set; }
      [JsonProperty("refereeName")]
public 				string

             refereeName
 { get; set; }
      [JsonProperty("referrerPhone")]
public 				string

             referrerPhone
 { get; set; }
      [JsonProperty("refereeNo")]
public 				string

             refereeNo
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("auditStatus")]
public 				int

             auditStatus
 { get; set; }
      [JsonProperty("licensCertificate")]
public 				string

             licensCertificate
 { get; set; }
	}
}
