using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DemandBillVo:JdObject{
      [JsonProperty("offer_lost_time")]
public 				string

                                                                                                                     offerLostTime
 { get; set; }
      [JsonProperty("demand_sn")]
public 				string

                                                                                     demandSn
 { get; set; }
      [JsonProperty("image_list")]
public 				List<string>

                                                                                     imageList
 { get; set; }
      [JsonProperty("vin_code")]
public 				string

                                                                                     vinCode
 { get; set; }
      [JsonProperty("offer_last_time")]
public 				string

                                                                                                                     offerLastTime
 { get; set; }
      [JsonProperty("status_key")]
public 				int

                                                                                     statusKey
 { get; set; }
      [JsonProperty("status_name")]
public 				string

                                                                                     statusName
 { get; set; }
      [JsonProperty("invoice_type")]
public 				int

                                                                                     invoiceType
 { get; set; }
      [JsonProperty("invoice_type_name")]
public 				string

                                                                                                                     invoiceTypeName
 { get; set; }
      [JsonProperty("invoice_title")]
public 				string

                                                                                     invoiceTitle
 { get; set; }
      [JsonProperty("tax_number")]
public 				string

                                                                                     taxNumber
 { get; set; }
      [JsonProperty("demand_desc")]
public 				string

                                                                                     demandDesc
 { get; set; }
      [JsonProperty("expect_quality")]
public 				string

                                                                                     expectQuality
 { get; set; }
      [JsonProperty("expect_quality_name")]
public 				string

                                                                                                                     expectQualityName
 { get; set; }
      [JsonProperty("other_fee")]
public 				string

                                                                                     otherFee
 { get; set; }
      [JsonProperty("shipping_type")]
public 				int

                                                                                     shippingType
 { get; set; }
      [JsonProperty("shipping_pay_way")]
public 				int

                                                                                                                     shippingPayWay
 { get; set; }
      [JsonProperty("offer_sn")]
public 				string

                                                                                     offerSn
 { get; set; }
      [JsonProperty("operate_name")]
public 				string

                                                                                     operateName
 { get; set; }
      [JsonProperty("customer_info_vo")]
public 				CustomerInfoVo

                                                                                                                     customerInfoVo
 { get; set; }
      [JsonProperty("carInfo_vo")]
public 				HawkCarInfoVo

                                                                                     carInfoVo
 { get; set; }
      [JsonProperty("detail_vo_list")]
public 				List<string>

                                                                                                                     detailVoList
 { get; set; }
	}
}
