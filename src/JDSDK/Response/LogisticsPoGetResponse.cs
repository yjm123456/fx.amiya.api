using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
												using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsPoGetResponse:JdResponse{
      [JsonProperty("inboundNo")]
public 				string

             inboundNo
 { get; set; }
      [JsonProperty("poNo")]
public 				string

             poNo
 { get; set; }
      [JsonProperty("receivingStatus")]
public 				string

             receivingStatus
 { get; set; }
      [JsonProperty("task_details")]
public 				List                     <ReceivingTask>

                                                                                     taskDetails
 { get; set; }
	}
}
