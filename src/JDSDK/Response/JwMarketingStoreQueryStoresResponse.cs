using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwMarketingStoreQueryStoresResponse:JdResponse{
      [JsonProperty("querystores_result")]
public 				StoreResponse

                                                                                     querystoresResult
 { get; set; }
	}
}
