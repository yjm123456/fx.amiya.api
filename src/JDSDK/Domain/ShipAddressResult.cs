using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShipAddressResult:JdObject{
      [JsonProperty("is_success")]
public 					bool

                                                                                     isSuccess
 { get; set; }
      [JsonProperty("error_code")]
public 				string

                                                                                     errorCode
 { get; set; }
      [JsonProperty("error_msg")]
public 				string

                                                                                     errorMsg
 { get; set; }
      [JsonProperty("total_count")]
public 				int

                                                                                     totalCount
 { get; set; }
      [JsonProperty("ship_address_s")]
public 				List<string>

                                                                                                                     shipAddressS
 { get; set; }
	}
}
