using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class FindStoresGroupListResponse:JdResponse{
      [JsonProperty("findstoresgrouplist_result")]
public 				ResultBean

                                                                                     findstoresgrouplistResult
 { get; set; }
	}
}
