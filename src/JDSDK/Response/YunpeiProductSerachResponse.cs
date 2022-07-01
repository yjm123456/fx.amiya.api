using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YunpeiProductSerachResponse:JdResponse{
      [JsonProperty("getgoodsinfo_result")]
public 				Result

                                                                                     getgoodsinfoResult
 { get; set; }
	}
}
