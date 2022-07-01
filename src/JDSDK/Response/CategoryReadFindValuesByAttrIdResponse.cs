using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CategoryReadFindValuesByAttrIdResponse:JdResponse{
      [JsonProperty("categoryAttrValues")]
public 				List<string>

             categoryAttrValues
 { get; set; }
	}
}
