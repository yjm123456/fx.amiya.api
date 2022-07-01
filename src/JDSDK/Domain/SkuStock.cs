using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuStock:JdObject{
      [JsonProperty("detailStock")]
public 				string

             detailStock
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("stockNum")]
public 				long

             stockNum
 { get; set; }
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
	}
}
