using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopJmGetUserBaseInfoByPinResponse:JdResponse{
      [JsonProperty("getuserbaseinfobypin_result")]
public 				UserBaseInfoVo

                                                                                     getuserbaseinfobypinResult
 { get; set; }
	}
}
