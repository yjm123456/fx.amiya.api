using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewhouseGetClueOrderDetailResponse:JdResponse{
      [JsonProperty("gethouseorderdetail_result")]
public 				HouseJosCustomerClueOrderResponse

                                                                                     gethouseorderdetailResult
 { get; set; }
	}
}
