using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
													namespace Jd.Api.Response
{

public class LogisticsOrderAddResponse:JdResponse{
      [JsonProperty("process_code")]
public 				long

                                                                                     processCode
 { get; set; }
      [JsonProperty("process_status")]
public 				string

                                                                                     processStatus
 { get; set; }
      [JsonProperty("error_message")]
public 				string

                                                                                     errorMessage
 { get; set; }
      [JsonProperty("result_no")]
public 				string

                                                                                     resultNo
 { get; set; }
	}
}
