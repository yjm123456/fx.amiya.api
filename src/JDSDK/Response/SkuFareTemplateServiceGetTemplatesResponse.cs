using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SkuFareTemplateServiceGetTemplatesResponse:JdResponse{
      [JsonProperty("query_skuFareTemplate_result")]
public 				SkuFareTemplateResult

                                                                                                                     querySkuFareTemplateResult
 { get; set; }
	}
}
