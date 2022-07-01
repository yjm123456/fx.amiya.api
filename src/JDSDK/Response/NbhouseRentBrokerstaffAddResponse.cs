using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NbhouseRentBrokerstaffAddResponse:JdResponse{
      [JsonProperty("addorupdatebrokerstaff_result")]
public 				RentBrokerStaffResult

                                                                                     addorupdatebrokerstaffResult
 { get; set; }
	}
}
