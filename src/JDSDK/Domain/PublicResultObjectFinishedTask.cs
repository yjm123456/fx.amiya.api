using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PublicResultObjectFinishedTask:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("finishedAfsService")]
public 				PageFinishedTask

             finishedAfsService
 { get; set; }
	}
}
