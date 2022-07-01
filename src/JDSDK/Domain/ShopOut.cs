using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopOut:JdObject{
      [JsonProperty("shopNo")]
public 				string

             shopNo
 { get; set; }
      [JsonProperty("isvShopNo")]
public 				string

             isvShopNo
 { get; set; }
      [JsonProperty("spSourceNo")]
public 				string

             spSourceNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("type")]
public 				string

             type
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("spShopNo")]
public 				string

             spShopNo
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
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("fax")]
public 				string

             fax
 { get; set; }
      [JsonProperty("afterSaleContacts")]
public 				string

             afterSaleContacts
 { get; set; }
      [JsonProperty("afterSaleAddress")]
public 				string

             afterSaleAddress
 { get; set; }
      [JsonProperty("afterSalePhone")]
public 				string

             afterSalePhone
 { get; set; }
      [JsonProperty("bdOwnerNo")]
public 				string

             bdOwnerNo
 { get; set; }
      [JsonProperty("outstoreRules")]
public 				string

             outstoreRules
 { get; set; }
      [JsonProperty("bizType")]
public 				string

             bizType
 { get; set; }
      [JsonProperty("reserve1")]
public 				string

             reserve1
 { get; set; }
      [JsonProperty("reserve2")]
public 				string

             reserve2
 { get; set; }
      [JsonProperty("reserve3")]
public 				string

             reserve3
 { get; set; }
      [JsonProperty("reserve4")]
public 				string

             reserve4
 { get; set; }
      [JsonProperty("reserve5")]
public 				string

             reserve5
 { get; set; }
      [JsonProperty("reserve6")]
public 				string

             reserve6
 { get; set; }
      [JsonProperty("reserve7")]
public 				string

             reserve7
 { get; set; }
      [JsonProperty("reserve8")]
public 				string

             reserve8
 { get; set; }
      [JsonProperty("reserve9")]
public 				string

             reserve9
 { get; set; }
      [JsonProperty("reserve10")]
public 				string

             reserve10
 { get; set; }
	}
}
