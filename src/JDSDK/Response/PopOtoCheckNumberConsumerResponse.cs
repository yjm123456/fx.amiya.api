using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOtoCheckNumberConsumerResponse:JdResponse{
      [JsonProperty("consume_result")]
public 				ConsumerResult

                                                                                     consumeResult
 { get; set; }
	}
}
