using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCategoryGetSecondLevelCategoriesResponse:JdResponse{
      [JsonProperty("categories")]
public 				List<string>

             categories
 { get; set; }
	}
}
