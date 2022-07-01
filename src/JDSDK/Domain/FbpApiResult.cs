using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FbpApiResult:JdObject{
      [JsonProperty("isSuccess")]
public 					bool

             isSuccess
 { get; set; }
      [JsonProperty("EnglishErrCode")]
public 				string

             EnglishErrCode
 { get; set; }
      [JsonProperty("ChineseErrCode")]
public 				string

             ChineseErrCode
 { get; set; }
      [JsonProperty("numberCode")]
public 				int

             numberCode
 { get; set; }
	}
}
