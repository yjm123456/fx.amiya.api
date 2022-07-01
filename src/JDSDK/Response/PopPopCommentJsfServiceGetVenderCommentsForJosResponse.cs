using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopPopCommentJsfServiceGetVenderCommentsForJosResponse:JdResponse{
      [JsonProperty("comments")]
public 				List<string>

             comments
 { get; set; }
      [JsonProperty("totalItem")]
public 				int

             totalItem
 { get; set; }
      [JsonProperty("page")]
public 				int

             page
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
	}
}
