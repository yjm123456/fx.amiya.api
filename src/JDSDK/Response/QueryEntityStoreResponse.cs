using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryEntityStoreResponse:JdResponse{
      [JsonProperty("queryentitystore_result")]
public 				ResultBean

                                                                                     queryentitystoreResult
 { get; set; }
	}
}
