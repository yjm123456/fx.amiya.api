using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarehouseOut:JdObject{
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
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
      [JsonProperty("isvWarehouseNo")]
public 				string

             isvWarehouseNo
 { get; set; }
	}
}
