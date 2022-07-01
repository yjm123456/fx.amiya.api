using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class KeywordQueryVO:JdObject{
      [JsonProperty("third_categoryid")]
public 				long

                                                                                     thirdCategoryid
 { get; set; }
      [JsonProperty("sort_field")]
public 				string

                                                                                     sortField
 { get; set; }
      [JsonProperty("sort_type")]
public 				int

                                                                                     sortType
 { get; set; }
      [JsonProperty("total_number")]
public 				int

                                                                                     totalNumber
 { get; set; }
      [JsonProperty("page_size")]
public 				int

                                                                                     pageSize
 { get; set; }
      [JsonProperty("page_index")]
public 				int

                                                                                     pageIndex
 { get; set; }
      [JsonProperty("keyword_data")]
public 				List<string>

                                                                                     keywordData
 { get; set; }
	}
}
