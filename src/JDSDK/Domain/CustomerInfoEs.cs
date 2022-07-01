using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerInfoEs:JdObject{
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("companyId")]
public 				long

             companyId
 { get; set; }
      [JsonProperty("userId")]
public 				long

             userId
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("levelAtJd")]
public 				string

             levelAtJd
 { get; set; }
      [JsonProperty("totalOrderPrice")]
public 				long

             totalOrderPrice
 { get; set; }
      [JsonProperty("totalOrderCount")]
public 				long

             totalOrderCount
 { get; set; }
      [JsonProperty("totalGoodsCount")]
public 				long

             totalGoodsCount
 { get; set; }
      [JsonProperty("canceledOrderCount")]
public 				int

             canceledOrderCount
 { get; set; }
      [JsonProperty("avgOrderPrice")]
public 				long

             avgOrderPrice
 { get; set; }
      [JsonProperty("lastOrderDate")]
public 				string

             lastOrderDate
 { get; set; }
      [JsonProperty("orderFrom")]
public 				int

             orderFrom
 { get; set; }
      [JsonProperty("firstOrderDate")]
public 				string

             firstOrderDate
 { get; set; }
      [JsonProperty("customerStatus")]
public 				int

             customerStatus
 { get; set; }
      [JsonProperty("levelAtShop")]
public 				int

             levelAtShop
 { get; set; }
      [JsonProperty("pcFlag")]
public 				int

             pcFlag
 { get; set; }
      [JsonProperty("phoneFlag")]
public 				int

             phoneFlag
 { get; set; }
      [JsonProperty("wxFlag")]
public 				int

             wxFlag
 { get; set; }
      [JsonProperty("increaseDate")]
public 				string

             increaseDate
 { get; set; }
      [JsonProperty("created")]
public 				string

             created
 { get; set; }
      [JsonProperty("modified")]
public 				string

             modified
 { get; set; }
      [JsonProperty("huanHuo")]
public 				long

             huanHuo
 { get; set; }
      [JsonProperty("tuidan")]
public 				long

             tuidan
 { get; set; }
      [JsonProperty("tuihuanMoney")]
public 				long

             tuihuanMoney
 { get; set; }
      [JsonProperty("points")]
public 				long

             points
 { get; set; }
	}
}
