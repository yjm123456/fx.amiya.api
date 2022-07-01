using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillExtraCharge:JdObject{
      [JsonProperty("insuredCharge")]
public 				string

             insuredCharge
 { get; set; }
      [JsonProperty("honorCharge")]
public 				string

             honorCharge
 { get; set; }
      [JsonProperty("specifiedSignCharge")]
public 				string

             specifiedSignCharge
 { get; set; }
      [JsonProperty("upStairsCharge")]
public 				string

             upStairsCharge
 { get; set; }
      [JsonProperty("intoWareHouseCharge")]
public 				string

             intoWareHouseCharge
 { get; set; }
      [JsonProperty("returnPermissionCharge")]
public 				string

             returnPermissionCharge
 { get; set; }
      [JsonProperty("guaranteeCharge")]
public 				string

             guaranteeCharge
 { get; set; }
      [JsonProperty("payAfterDeliveryCharge")]
public 				string

             payAfterDeliveryCharge
 { get; set; }
      [JsonProperty("electronicSignCharge")]
public 				string

             electronicSignCharge
 { get; set; }
      [JsonProperty("transferGoodsCharge")]
public 				string

             transferGoodsCharge
 { get; set; }
      [JsonProperty("loadCharge")]
public 				string

             loadCharge
 { get; set; }
      [JsonProperty("unLoadCharge")]
public 				string

             unLoadCharge
 { get; set; }
      [JsonProperty("collectCharge")]
public 				string

             collectCharge
 { get; set; }
      [JsonProperty("deliveryCharge")]
public 				string

             deliveryCharge
 { get; set; }
      [JsonProperty("peakPeriodCharge")]
public 				string

             peakPeriodCharge
 { get; set; }
      [JsonProperty("oldReceivedFee")]
public 				string

             oldReceivedFee
 { get; set; }
	}
}
