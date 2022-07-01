using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderGetRemarkByCreateTimeResponse:JdResponse{
      [JsonProperty("getremarkbymodifytime_result")]
public 				OrderRemarkResult

                                                                                     getremarkbymodifytimeResult
 { get; set; }
	}
}
