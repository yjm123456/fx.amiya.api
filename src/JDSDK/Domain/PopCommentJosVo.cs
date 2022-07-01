using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PopCommentJosVo:JdObject{
      [JsonProperty("commentId")]
public 				string

             commentId
 { get; set; }
      [JsonProperty("skuid")]
public 				string

             skuid
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("creationTime")]
public 				DateTime

             creationTime
 { get; set; }
      [JsonProperty("skuImage")]
public 				string

             skuImage
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("replyCount")]
public 				int

             replyCount
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("score")]
public 				int

             score
 { get; set; }
      [JsonProperty("usefulCount")]
public 				int

             usefulCount
 { get; set; }
      [JsonProperty("isVenderReply")]
public 				bool

             isVenderReply
 { get; set; }
      [JsonProperty("nickName")]
public 				string

             nickName
 { get; set; }
      [JsonProperty("replies")]
public 				List<string>

             replies
 { get; set; }
      [JsonProperty("images")]
public 				List<string>

             images
 { get; set; }
      [JsonProperty("videos")]
public 				List<string>

             videos
 { get; set; }
      [JsonProperty("imiageStatus")]
public 				int

             imiageStatus
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
