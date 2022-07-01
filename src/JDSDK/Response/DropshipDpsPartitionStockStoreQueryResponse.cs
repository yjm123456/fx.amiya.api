using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DropshipDpsPartitionStockStoreQueryResponse:JdResponse{
      [JsonProperty("getstoreinfosbyvendor_result")]
public 				DropshipStoreResult

                                                                                     getstoreinfosbyvendorResult
 { get; set; }
	}
}
