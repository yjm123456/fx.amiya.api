using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductJosStringDto:JdObject{
      [JsonProperty("is_success")]
public 					bool

                                                                                     isSuccess
 { get; set; }
      [JsonProperty("return_code")]
public 				string

                                                                                     returnCode
 { get; set; }
      [JsonProperty("return_message")]
public 				string

                                                                                     returnMessage
 { get; set; }
      [JsonProperty("single_obj")]
public 				string

                                                                                     singleObj
 { get; set; }
	}
}
