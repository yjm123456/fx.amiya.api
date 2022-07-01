using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApiOrderPrintData:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("out_bound_date")]
public 				string

                                                                                                                     outBoundDate
 { get; set; }
      [JsonProperty("bf_deli_good_glag")]
public 				string

                                                                                                                                                     bfDeliGoodGlag
 { get; set; }
      [JsonProperty("cod_time_name")]
public 				string

                                                                                                                     codTimeName
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("cky2_name")]
public 				string

                                                                                     cky2Name
 { get; set; }
      [JsonProperty("sorting_code")]
public 				string

                                                                                     sortingCode
 { get; set; }
      [JsonProperty("create_date")]
public 				string

                                                                                     createDate
 { get; set; }
      [JsonProperty("should_pay")]
public 				string

                                                                                     shouldPay
 { get; set; }
      [JsonProperty("payment_typeStr")]
public 				string

                                                                                     paymentTypeStr
 { get; set; }
      [JsonProperty("partner")]
public 				string

             partner
 { get; set; }
      [JsonProperty("generade")]
public 				string

             generade
 { get; set; }
      [JsonProperty("items_count")]
public 				string

                                                                                     itemsCount
 { get; set; }
      [JsonProperty("order_items")]
public 				List<string>

                                                                                     orderItems
 { get; set; }
      [JsonProperty("Consignee")]
public 				OrderPrintDataConsignee

             Consignee
 { get; set; }
      [JsonProperty("pickUpSign")]
public 				string

             pickUpSign
 { get; set; }
      [JsonProperty("orderLevelSign")]
public 				string

             orderLevelSign
 { get; set; }
      [JsonProperty("freight")]
public 					string

             freight
 { get; set; }
      [JsonProperty("codDT")]
public 				string

             codDT
 { get; set; }
	}
}
