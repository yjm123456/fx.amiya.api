using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryStockHouseRentResult:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("error_code")]
public 				string

                                                                                     errorCode
 { get; set; }
      [JsonProperty("error_msg")]
public 				string

                                                                                     errorMsg
 { get; set; }
      [JsonProperty("rentstoreinfo_list")]
public 				List<string>

                                                                                     rentstoreinfoList
 { get; set; }
	}
}
