using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JOSVideoInfo:JdObject{
      [JsonProperty("video_id")]
public 				long

                                                                                     videoId
 { get; set; }
      [JsonProperty("video_name")]
public 				string

                                                                                     videoName
 { get; set; }
      [JsonProperty("video_desc")]
public 				string

                                                                                     videoDesc
 { get; set; }
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("video_size")]
public 				int

                                                                                     videoSize
 { get; set; }
      [JsonProperty("cover")]
public 				string

             cover
 { get; set; }
      [JsonProperty("verifier")]
public 				string

             verifier
 { get; set; }
      [JsonProperty("verify_desc")]
public 				string

                                                                                     verifyDesc
 { get; set; }
      [JsonProperty("created_date")]
public 				DateTime

                                                                                     createdDate
 { get; set; }
      [JsonProperty("modified_date")]
public 				DateTime

                                                                                     modifiedDate
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("apply_reason")]
public 				string

                                                                                     applyReason
 { get; set; }
      [JsonProperty("time")]
public 				int

             time
 { get; set; }
      [JsonProperty("agent_video_id")]
public 				long

                                                                                                                     agentVideoId
 { get; set; }
      [JsonProperty("video_type")]
public 				int

                                                                                     videoType
 { get; set; }
      [JsonProperty("play_url")]
public 				string

                                                                                     playUrl
 { get; set; }
      [JsonProperty("rel_apply_count")]
public 				int

                                                                                                                     relApplyCount
 { get; set; }
      [JsonProperty("rel_pass_count")]
public 				int

                                                                                                                     relPassCount
 { get; set; }
      [JsonProperty("rel_reject_count")]
public 				int

                                                                                                                     relRejectCount
 { get; set; }
	}
}
