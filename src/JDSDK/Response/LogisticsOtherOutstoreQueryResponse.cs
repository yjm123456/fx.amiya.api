using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
																								using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsOtherOutstoreQueryResponse:JdResponse{
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
      [JsonProperty("josl_outbound_no")]
public 				string

                                                                                                                     joslOutboundNo
 { get; set; }
      [JsonProperty("isv_outbound_no")]
public 				string

                                                                                                                     isvOutboundNo
 { get; set; }
      [JsonProperty("josl_status")]
public 				string

                                                                                     joslStatus
 { get; set; }
      [JsonProperty("complete_time")]
public 				DateTime

                                                                                     completeTime
 { get; set; }
      [JsonProperty("order_details")]
public 				List<string>

                                                                                     orderDetails
 { get; set; }
      [JsonProperty("carriers_id")]
public 				string

                                                                                     carriersId
 { get; set; }
      [JsonProperty("carriers_name")]
public 				string

                                                                                     carriersName
 { get; set; }
      [JsonProperty("delivery_no_list")]
public 				string

                                                                                                                     deliveryNoList
 { get; set; }
	}
}
