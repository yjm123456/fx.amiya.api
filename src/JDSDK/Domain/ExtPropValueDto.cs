using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExtPropValueDto:JdObject{
      [JsonProperty("value_id")]
public 				int

                                                                                     valueId
 { get; set; }
      [JsonProperty("att_id")]
public 				int

                                                                                     attId
 { get; set; }
      [JsonProperty("value_name")]
public 				string

                                                                                     valueName
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("brand_prx")]
public 				string

                                                                                     brandPrx
 { get; set; }
      [JsonProperty("sort")]
public 				int

             sort
 { get; set; }
      [JsonProperty("grade_avg")]
public 				int

                                                                                     gradeAvg
 { get; set; }
      [JsonProperty("remarks")]
public 				string

             remarks
 { get; set; }
      [JsonProperty("is_required")]
public 				int

                                                                                     isRequired
 { get; set; }
	}
}
