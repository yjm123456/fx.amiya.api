using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JOSPageResult:JdObject{
      [JsonProperty("page_index")]
public 				int

                                                                                     pageIndex
 { get; set; }
      [JsonProperty("page_size")]
public 				int

                                                                                     pageSize
 { get; set; }
      [JsonProperty("total_count")]
public 				int

                                                                                     totalCount
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
