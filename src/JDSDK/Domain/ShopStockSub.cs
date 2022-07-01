using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopStockSub:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("shopNo")]
public 				string

             shopNo
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
	}
}
