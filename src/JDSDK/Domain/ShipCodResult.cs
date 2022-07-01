using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShipCodResult:JdObject{
      [JsonProperty("supportJdShip")]
public 				bool

             supportJdShip
 { get; set; }
      [JsonProperty("supportFreshShip")]
public 				bool

             supportFreshShip
 { get; set; }
      [JsonProperty("supportJdCod")]
public 				bool

             supportJdCod
 { get; set; }
      [JsonProperty("supportJdPos")]
public 				bool

             supportJdPos
 { get; set; }
      [JsonProperty("supportJd3Cod")]
public 				bool

             supportJd3Cod
 { get; set; }
      [JsonProperty("supportSpecialDelivery")]
public 				bool

             supportSpecialDelivery
 { get; set; }
      [JsonProperty("supportCold1")]
public 				bool

             supportCold1
 { get; set; }
      [JsonProperty("supportCold2")]
public 				bool

             supportCold2
 { get; set; }
      [JsonProperty("supportCold3")]
public 				bool

             supportCold3
 { get; set; }
      [JsonProperty("supportCold4")]
public 				bool

             supportCold4
 { get; set; }
      [JsonProperty("supportDirect")]
public 				bool

             supportDirect
 { get; set; }
      [JsonProperty("supportPickup")]
public 				bool

             supportPickup
 { get; set; }
      [JsonProperty("supportHKMOShip")]
public 				bool

             supportHKMOShip
 { get; set; }
      [JsonProperty("unSupportGAShipProducts")]
public 				string

             unSupportGAShipProducts
 { get; set; }
      [JsonProperty("unSupportFreshShipProducts")]
public 				string

             unSupportFreshShipProducts
 { get; set; }
      [JsonProperty("shipType")]
public 				int

             shipType
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
	}
}
