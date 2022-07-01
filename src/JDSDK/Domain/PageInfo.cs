using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageInfo:JdObject{
      [JsonProperty("page_index")]
public 				long

                                                                                     pageIndex
 { get; set; }
      [JsonProperty("page_total")]
public 				long

                                                                                     pageTotal
 { get; set; }
      [JsonProperty("page_size")]
public 				long

                                                                                     pageSize
 { get; set; }
      [JsonProperty("datas")]
public 				List<string>

             datas
 { get; set; }
	}
}
