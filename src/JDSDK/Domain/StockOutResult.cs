using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockOutResult:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("error_code")]
public 				string

                                                                                     errorCode
 { get; set; }
      [JsonProperty("error_msg")]
public 				string

                                                                                     errorMsg
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("stock_out_time")]
public 				DateTime

                                                                                                                     stockOutTime
 { get; set; }
      [JsonProperty("skuinfo_list")]
public 				List<string>

                                                                                     skuinfoList
 { get; set; }
	}
}
