using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageResult:JdObject{
      [JsonProperty("result_code")]
public 				int

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("size")]
public 				int

             size
 { get; set; }
      [JsonProperty("page")]
public 				int

             page
 { get; set; }
      [JsonProperty("total_elements")]
public 				long

                                                                                     totalElements
 { get; set; }
      [JsonProperty("total_page")]
public 				long

                                                                                     totalPage
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
