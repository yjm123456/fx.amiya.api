using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JOSOrderResultDto:JdObject{
      [JsonProperty("record_count")]
public 				int

                                                                                     recordCount
 { get; set; }
      [JsonProperty("purchase_order_list")]
public 				List<string>

                                                                                                                     purchaseOrderList
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("result_code")]
public 				string

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
	}
}
