using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordNewkeywordInsertRequest : JdRequestBase<DspAdkckeywordNewkeywordInsertResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  name {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  type {get; set; }
                                                                                                                                                                                                                                 public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.newkeyword.insert";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                            }
    }
}





        
 

