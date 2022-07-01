using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemInfoDTO:JdObject{
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("itemTotal")]
public 				int

             itemTotal
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("goodCatName")]
public 				string

             goodCatName
 { get; set; }
      [JsonProperty("jdPrice")]
public 					string

             jdPrice
 { get; set; }
      [JsonProperty("outerId")]
public 				string

             outerId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
	}
}
