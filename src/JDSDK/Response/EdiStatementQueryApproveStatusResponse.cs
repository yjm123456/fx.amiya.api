using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiStatementQueryApproveStatusResponse:JdResponse{
      [JsonProperty("statementApproveResultDTO")]
public 				JosStatementApproveResultDTO

             statementApproveResultDTO
 { get; set; }
	}
}
