using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockDto:JdObject{
      [JsonProperty("skuNo")]
public 				string

             skuNo
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("qty")]
public 					string

             qty
 { get; set; }
      [JsonProperty("canLocateQty")]
public 					string

             canLocateQty
 { get; set; }
      [JsonProperty("allQty")]
public 					string

             allQty
 { get; set; }
      [JsonProperty("ownerNo")]
public 				string

             ownerNo
 { get; set; }
      [JsonProperty("productLevel")]
public 				string

             productLevel
 { get; set; }
      [JsonProperty("productLevelName")]
public 				string

             productLevelName
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("tenantId")]
public 				string

             tenantId
 { get; set; }
	}
}
