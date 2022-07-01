using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImagePathDtoLong:JdObject{
      [JsonProperty("is_primary_long")]
public 				int

                                                                                                                     isPrimaryLong
 { get; set; }
      [JsonProperty("order_sort_long")]
public 				int

                                                                                                                     orderSortLong
 { get; set; }
      [JsonProperty("path_long")]
public 				string

                                                                                     pathLong
 { get; set; }
	}
}
