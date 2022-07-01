using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SdkPageResult:JdObject{
      [JsonProperty("pageCount")]
public 				int

             pageCount
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("totalItem")]
public 				int

             totalItem
 { get; set; }
      [JsonProperty("pageNo")]
public 				int

             pageNo
 { get; set; }
      [JsonProperty("dataList")]
public 				List<string>

             dataList
 { get; set; }
      [JsonProperty("errorMessage")]
public 				string

             errorMessage
 { get; set; }
      [JsonProperty("pageSize")]
public 				int

             pageSize
 { get; set; }
      [JsonProperty("reqId")]
public 				string

             reqId
 { get; set; }
      [JsonProperty("isSuccess")]
public 					bool

             isSuccess
 { get; set; }
	}
}
