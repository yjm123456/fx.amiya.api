using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuStoreStockNumInfo:JdObject{
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
      [JsonProperty("storeId")]
public 				int

             storeId
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("availableStockNum")]
public 				int

             availableStockNum
 { get; set; }
	}
}
