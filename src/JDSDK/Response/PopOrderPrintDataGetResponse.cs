using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderPrintDataGetResponse:JdResponse{
      [JsonProperty("getorderprintdata_result")]
public 				OrderPrintDataResult

                                                                                     getorderprintdataResult
 { get; set; }
	}
}
