using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class ShopcategoriesReadFindShopCategoriesByWareIdResponse:JdResponse{
      [JsonProperty("shopCategories")]
public 				List<string>

             shopCategories
 { get; set; }
	}
}
