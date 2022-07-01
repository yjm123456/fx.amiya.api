using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiAsnSendResponse:JdResponse{
      [JsonProperty("addadvancedshipmentnote_result")]
public 				JosAsnResult

                                                                                     addadvancedshipmentnoteResult
 { get; set; }
	}
}
