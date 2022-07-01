using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderResponse:JdObject{
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
      [JsonProperty("total_page")]
public 				int

                                                                                     totalPage
 { get; set; }
      [JsonProperty("cur_page_num")]
public 				int

                                                                                                                     curPageNum
 { get; set; }
      [JsonProperty("order_list")]
public 				List<string>

                                                                                     orderList
 { get; set; }
	}
}
