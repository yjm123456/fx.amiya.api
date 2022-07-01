using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PropValueDto:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("order_sort")]
public 				int

                                                                                     orderSort
 { get; set; }
      [JsonProperty("selected")]
public 					bool

             selected
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
	}
}
