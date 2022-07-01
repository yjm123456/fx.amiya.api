using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQueryStoreInfoResponse:JdResponse{
      [JsonProperty("queryStoreInfo_result")]
public 				StoreResponse

                                                                                     queryStoreInfoResult
 { get; set; }
	}
}
