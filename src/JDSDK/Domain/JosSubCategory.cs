using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSubCategory:JdObject{
      [JsonProperty("category_id")]
public 				int

                                                                                     categoryId
 { get; set; }
      [JsonProperty("category_name")]
public 				string

                                                                                     categoryName
 { get; set; }
      [JsonProperty("category_level")]
public 				int

                                                                                     categoryLevel
 { get; set; }
      [JsonProperty("parent_id")]
public 				int

                                                                                     parentId
 { get; set; }
	}
}
