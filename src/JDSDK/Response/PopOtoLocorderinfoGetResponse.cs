using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOtoLocorderinfoGetResponse:JdResponse{
      [JsonProperty("loccodeinfo_result")]
public 				LocCodeInfoResult

                                                                                     loccodeinfoResult
 { get; set; }
	}
}
