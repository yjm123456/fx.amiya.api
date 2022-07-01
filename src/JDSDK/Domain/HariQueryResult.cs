using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HariQueryResult:JdObject{
      [JsonProperty("bookNo")]
public 				string

             bookNo
 { get; set; }
      [JsonProperty("bookDate")]
public 				string

             bookDate
 { get; set; }
      [JsonProperty("supNo")]
public 				string

             supNo
 { get; set; }
      [JsonProperty("poNo")]
public 				string

             poNo
 { get; set; }
      [JsonProperty("whNo")]
public 				int

             whNo
 { get; set; }
      [JsonProperty("dcNo")]
public 				int

             dcNo
 { get; set; }
      [JsonProperty("ownerNo")]
public 				string

             ownerNo
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("bookTimePeriod")]
public 				string

             bookTimePeriod
 { get; set; }
      [JsonProperty("bookTime")]
public 				string

             bookTime
 { get; set; }
	}
}
