using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiStatementQueryStatementResponse:JdResponse{
      [JsonProperty("josStatementResultDTO")]
public 				JosStatementResultDTO

             josStatementResultDTO
 { get; set; }
	}
}
