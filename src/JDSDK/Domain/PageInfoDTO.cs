using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PageInfoDTO:JdObject{
      [JsonProperty("total_product_num")]
public 				int

                                                                                                                     totalProductNum
 { get; set; }
      [JsonProperty("page_num")]
public 				int

                                                                                     pageNum
 { get; set; }
      [JsonProperty("down_num")]
public 				int

                                                                                     downNum
 { get; set; }
      [JsonProperty("page_no")]
public 				int

                                                                                     pageNo
 { get; set; }
      [JsonProperty("product_info_list")]
public 				List<string>

                                                                                                                     productInfoList
 { get; set; }
	}
}
