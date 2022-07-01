using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DropshipDpsPartitionStockInfoQueryResponse:JdResponse{
      [JsonProperty("querypartitionstockinfos_result")]
public 				DropshipResult

                                                                                     querypartitionstockinfosResult
 { get; set; }
	}
}
