using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiRealtimeinventoryQueryRequest : JdRequestBase<EdiRealtimeinventoryQueryResponse>
    {
                                                                                                                                              public  		string
              operatorErp
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  jdSku {get; set; }
                                                                                                                                                                                                                                 public  		string
              vendorCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.realtimeinventory.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operatorErp", this.            operatorErp
);
                                                                                                                                                parameters.Add("jdSku", this.            jdSku
);
                                                                                                                                                                                parameters.Add("vendorCode", this.            vendorCode
);
                                                                            }
    }
}





        
 

