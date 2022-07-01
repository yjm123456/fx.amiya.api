using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CategoryReadFindAttrByIdResponse:JdResponse{
      [JsonProperty("categoryAttr")]
public 				CategoryAttr

             categoryAttr
 { get; set; }
	}
}
