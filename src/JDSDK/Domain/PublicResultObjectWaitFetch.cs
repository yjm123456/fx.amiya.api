using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PublicResultObjectWaitFetch:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultErrorMsg")]
public 				string

             resultErrorMsg
 { get; set; }
      [JsonProperty("waitFetch")]
public 				PageWaitFetch

             waitFetch
 { get; set; }
	}
}
