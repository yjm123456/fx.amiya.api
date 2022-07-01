using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiRoDetailBatchGetResponse:JdResponse{
      [JsonProperty("returnOrderLineBatchResultDTO")]
public 				JosReturnOrderLineBatchResultDTO

             returnOrderLineBatchResultDTO
 { get; set; }
	}
}
