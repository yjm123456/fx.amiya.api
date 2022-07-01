using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OperatorResult:JdObject{
      [JsonProperty("chinese_err_code")]
public 				string

                                                                                                                     chineseErrCode
 { get; set; }
      [JsonProperty("english_err_code")]
public 				string

                                                                                                                     englishErrCode
 { get; set; }
      [JsonProperty("error_code")]
public 				string

                                                                                     errorCode
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("out_batch_id")]
public 				long

                                                                                                                     outBatchId
 { get; set; }
      [JsonProperty("sendbatch_id")]
public 				long

                                                                                     sendbatchId
 { get; set; }
	}
}
