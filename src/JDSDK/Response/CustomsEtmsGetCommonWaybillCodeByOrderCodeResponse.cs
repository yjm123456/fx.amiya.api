using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CustomsEtmsGetCommonWaybillCodeByOrderCodeResponse:JdResponse{
      [JsonProperty("wayBillNoResponse")]
public 				WayBillNoResponse

             wayBillNoResponse
 { get; set; }
	}
}
