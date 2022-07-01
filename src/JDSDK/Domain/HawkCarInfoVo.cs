using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HawkCarInfoVo:JdObject{
      [JsonProperty("car_model_id")]
public 				int

                                                                                                                     carModelId
 { get; set; }
      [JsonProperty("car_model")]
public 				string

                                                                                     carModel
 { get; set; }
      [JsonProperty("car_brand_id")]
public 				int

                                                                                                                     carBrandId
 { get; set; }
      [JsonProperty("car_brand")]
public 				string

                                                                                     carBrand
 { get; set; }
      [JsonProperty("car_series_id")]
public 				int

                                                                                                                     carSeriesId
 { get; set; }
      [JsonProperty("car_series")]
public 				string

                                                                                     carSeries
 { get; set; }
      [JsonProperty("car_power_id")]
public 				int

                                                                                                                     carPowerId
 { get; set; }
      [JsonProperty("car_power")]
public 				string

                                                                                     carPower
 { get; set; }
      [JsonProperty("car_year_id")]
public 				int

                                                                                                                     carYearId
 { get; set; }
      [JsonProperty("car_year")]
public 				string

                                                                                     carYear
 { get; set; }
      [JsonProperty("car_name")]
public 				string

                                                                                     carName
 { get; set; }
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
	}
}
