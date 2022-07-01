using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PresortSitefenceimportServiceResponse:JdResponse{
      [JsonProperty("sitefenceimport_result")]
public 				FenceImportResponseDto

                                                                                     sitefenceimportResult
 { get; set; }
	}
}
