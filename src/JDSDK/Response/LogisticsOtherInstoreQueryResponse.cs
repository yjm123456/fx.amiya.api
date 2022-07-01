using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
																								using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsOtherInstoreQueryResponse:JdResponse{
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
      [JsonProperty("inbound_no")]
public 				string

                                                                                     inboundNo
 { get; set; }
      [JsonProperty("po_no")]
public 				string

                                                                                     poNo
 { get; set; }
      [JsonProperty("inbound_status")]
public 				string

                                                                                     inboundStatus
 { get; set; }
      [JsonProperty("status_update_time")]
public 				DateTime

                                                                                                                     statusUpdateTime
 { get; set; }
      [JsonProperty("task_details")]
public 				List<string>

                                                                                     taskDetails
 { get; set; }
	}
}
