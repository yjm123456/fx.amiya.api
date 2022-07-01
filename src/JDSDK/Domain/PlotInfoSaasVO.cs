using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PlotInfoSaasVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("plotId")]
public 				long

             plotId
 { get; set; }
      [JsonProperty("plotName")]
public 				string

             plotName
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("location")]
public 				string

             location
 { get; set; }
      [JsonProperty("firstCode")]
public 				int

             firstCode
 { get; set; }
      [JsonProperty("secondCode")]
public 				int

             secondCode
 { get; set; }
      [JsonProperty("thirdCode")]
public 				int

             thirdCode
 { get; set; }
      [JsonProperty("firstName")]
public 				string

             firstName
 { get; set; }
      [JsonProperty("secondName")]
public 				string

             secondName
 { get; set; }
      [JsonProperty("thirdName")]
public 				string

             thirdName
 { get; set; }
      [JsonProperty("addressDes")]
public 				string

             addressDes
 { get; set; }
      [JsonProperty("distance")]
public 				double

             distance
 { get; set; }
      [JsonProperty("averagePrice")]
public 				double

             averagePrice
 { get; set; }
      [JsonProperty("ifCityUse")]
public 					bool

             ifCityUse
 { get; set; }
	}
}
