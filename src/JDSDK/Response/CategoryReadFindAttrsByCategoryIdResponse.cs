using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CategoryReadFindAttrsByCategoryIdResponse:JdResponse{
      [JsonProperty("categoryAttrs")]
public 				List<string>

             categoryAttrs
 { get; set; }
	}
}
