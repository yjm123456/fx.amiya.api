using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IncomeExpenseVO:JdObject{
      [JsonProperty("swift_number")]
public 				long

                                                                                     swiftNumber
 { get; set; }
      [JsonProperty("creat_time")]
public 				string

                                                                                     creatTime
 { get; set; }
      [JsonProperty("amount")]
public 				long

             amount
 { get; set; }
      [JsonProperty("in_out_type")]
public 				long

                                                                                                                     inOutType
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("show_date")]
public 				string

                                                                                     showDate
 { get; set; }
	}
}
