using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareSkuApiVO:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("rfId")]
public 				string

             rfId
 { get; set; }
      [JsonProperty("attributes")]
public 				string

             attributes
 { get; set; }
      [JsonProperty("supplyPrice")]
public 					string

             supplyPrice
 { get; set; }
      [JsonProperty("stock")]
public 				int

             stock
 { get; set; }
      [JsonProperty("imgUri")]
public 				string

             imgUri
 { get; set; }
      [JsonProperty("hsCode")]
public 				string

             hsCode
 { get; set; }
	}
}
