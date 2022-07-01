using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class UserGetUserInfoByOpenIdResponse:JdResponse{
      [JsonProperty("getuserinfobyappidandopenid_result")]
public 				Result

                                                                                     getuserinfobyappidandopenidResult
 { get; set; }
	}
}
