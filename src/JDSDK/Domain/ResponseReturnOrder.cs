using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseReturnOrder:JdObject{
      [JsonProperty("process_code")]
public 				int

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
      [JsonProperty("josl_inbound_no")]
public 				string

                                                                                                                     joslInboundNo
 { get; set; }
      [JsonProperty("return_order_no")]
public 				string

                                                                                                                     returnOrderNo
 { get; set; }
      [JsonProperty("josl_outbound_no")]
public 				string

                                                                                                                     joslOutboundNo
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("complete_time")]
public 				string

                                                                                     completeTime
 { get; set; }
	}
}
