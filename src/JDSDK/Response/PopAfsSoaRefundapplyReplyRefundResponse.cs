using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopAfsSoaRefundapplyReplyRefundResponse:JdResponse{
      [JsonProperty("replyResult")]
public 				ReplyResult

             replyResult
 { get; set; }
	}
}
