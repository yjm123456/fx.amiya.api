using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductSort:JdObject{
      [JsonProperty("product_sort_id")]
public 				int

                                                                                                                     productSortId
 { get; set; }
      [JsonProperty("father_id")]
public 				int

                                                                                     fatherId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("is_delete")]
public 				int

                                                                                     isDelete
 { get; set; }
      [JsonProperty("grade")]
public 				int

             grade
 { get; set; }
      [JsonProperty("conte")]
public 				string

             conte
 { get; set; }
      [JsonProperty("sort")]
public 				int

             sort
 { get; set; }
      [JsonProperty("is_fit_service")]
public 				int

                                                                                                                     isFitService
 { get; set; }
	}
}
