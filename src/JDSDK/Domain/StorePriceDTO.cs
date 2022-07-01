using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StorePriceDTO:JdObject{
      [JsonProperty("storePrice")]
public 					string

             storePrice
 { get; set; }
      [JsonProperty("outerId")]
public 				string

             outerId
 { get; set; }
      [JsonProperty("exStoreId")]
public 				string

             exStoreId
 { get; set; }
      [JsonProperty("storeId")]
public 				string

             storeId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
	}
}
