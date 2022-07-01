using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VmiShopStock:JdObject{
      [JsonProperty("shopNo")]
public 				string

             shopNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("spGoodsNo")]
public 				string

             spGoodsNo
 { get; set; }
      [JsonProperty("stockNum")]
public 				int[]

             stockNum
 { get; set; }
      [JsonProperty("occupyNum")]
public 				int[]

             occupyNum
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
	}
}
