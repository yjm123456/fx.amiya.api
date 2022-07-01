using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class FindStoreOrderIdListByCouponCodeListResponse:JdResponse{
      [JsonProperty("result")]
public 				ResultBean

             result
 { get; set; }
	}
}
