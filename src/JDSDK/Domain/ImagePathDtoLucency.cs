using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImagePathDtoLucency:JdObject{
      [JsonProperty("is_primary_lucency")]
public 				int

                                                                                                                     isPrimaryLucency
 { get; set; }
      [JsonProperty("order_sort_lucency")]
public 				int

                                                                                                                     orderSortLucency
 { get; set; }
      [JsonProperty("path_lucency")]
public 				string

                                                                                     pathLucency
 { get; set; }
	}
}
