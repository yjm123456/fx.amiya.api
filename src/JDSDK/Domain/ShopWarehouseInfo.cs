using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopWarehouseInfo:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("shopNos")]
public 				string

             shopNos
 { get; set; }
      [JsonProperty("warehouseNos")]
public 				string

             warehouseNos
 { get; set; }
	}
}
