using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseStock:JdObject{
      [JsonProperty("process_code")]
public 				string

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
      [JsonProperty("total_page")]
public 				int

                                                                                     totalPage
 { get; set; }
      [JsonProperty("stock_details")]
public 				List<string>

                                                                                     stockDetails
 { get; set; }
	}
}
