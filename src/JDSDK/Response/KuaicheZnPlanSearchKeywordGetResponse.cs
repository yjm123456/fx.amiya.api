using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnPlanSearchKeywordGetResponse:JdResponse{
      [JsonProperty("keywords_info")]
public 				List<string>

                                                                                     keywordsInfo
 { get; set; }
	}
}
