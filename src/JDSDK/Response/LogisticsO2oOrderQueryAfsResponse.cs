using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsO2oOrderQueryAfsResponse:JdResponse{
      [JsonProperty("Afs_Service_Response")]
public 				AfsServiceResponse

                                                                                                                     afsServiceResponse
 { get; set; }
	}
}
