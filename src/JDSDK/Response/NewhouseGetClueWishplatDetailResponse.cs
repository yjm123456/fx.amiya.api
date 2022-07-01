using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewhouseGetClueWishplatDetailResponse:JdResponse{
      [JsonProperty("gethousewishplatdetail_result")]
public 				HouseJosCustomerClueWishplatResponse

                                                                                     gethousewishplatdetailResult
 { get; set; }
	}
}
