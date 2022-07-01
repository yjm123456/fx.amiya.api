using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseWarePropertyDto:JdObject{
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("chest")]
public 				double

             chest
 { get; set; }
      [JsonProperty("waistline")]
public 				double

             waistline
 { get; set; }
      [JsonProperty("hip")]
public 				double

             hip
 { get; set; }
      [JsonProperty("dress_length")]
public 				double

                                                                                     dressLength
 { get; set; }
      [JsonProperty("height")]
public 				double

             height
 { get; set; }
      [JsonProperty("color")]
public 				string

             color
 { get; set; }
	}
}
