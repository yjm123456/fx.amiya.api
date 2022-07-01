using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VendorCommentReplyDTO:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("result")]
public 				string

             result
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
	}
}
