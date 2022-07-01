using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SamOrderDetailQuerynewResponse:JdResponse{
      [JsonProperty("queryorderdetail_result")]
public 				OrderDetailResult

                                                                                     queryorderdetailResult
 { get; set; }
	}
}
