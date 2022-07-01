using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PopCommentReplyVo:JdObject{
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("creationTime")]
public 				DateTime

             creationTime
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("replyId")]
public 				long

             replyId
 { get; set; }
	}
}
