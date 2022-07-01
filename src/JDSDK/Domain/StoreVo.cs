using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StoreVo:JdObject{
      [JsonProperty("storeName")]
public 				string

             storeName
 { get; set; }
      [JsonProperty("storeType")]
public 				int

             storeType
 { get; set; }
      [JsonProperty("storeBusinessModel")]
public 				int

             storeBusinessModel
 { get; set; }
      [JsonProperty("area")]
public 					string

             area
 { get; set; }
      [JsonProperty("openFlag")]
public 				int

             openFlag
 { get; set; }
      [JsonProperty("crowdsourcingFlag")]
public 				int

             crowdsourcingFlag
 { get; set; }
      [JsonProperty("selfPickFlag")]
public 				int

             selfPickFlag
 { get; set; }
      [JsonProperty("deliverFlag")]
public 				int

             deliverFlag
 { get; set; }
      [JsonProperty("sellerControlStock")]
public 				int

             sellerControlStock
 { get; set; }
      [JsonProperty("storeSystem")]
public 				string

             storeSystem
 { get; set; }
      [JsonProperty("contacts")]
public 				string

             contacts
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("county")]
public 				string

             county
 { get; set; }
      [JsonProperty("town")]
public 				string

             town
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("postCode")]
public 				string

             postCode
 { get; set; }
      [JsonProperty("distributionScope")]
public 				string

             distributionScope
 { get; set; }
      [JsonProperty("geographicCoordinate")]
public 				string

             geographicCoordinate
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("jdstore")]
public 				int

             jdstore
 { get; set; }
	}
}
