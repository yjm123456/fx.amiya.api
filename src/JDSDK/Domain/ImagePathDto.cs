using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImagePathDto:JdObject{
      [JsonProperty("is_primary")]
public 				int

                                                                                     isPrimary
 { get; set; }
      [JsonProperty("order_sort")]
public 				int

                                                                                     orderSort
 { get; set; }
      [JsonProperty("path")]
public 				string

             path
 { get; set; }
	}
}
