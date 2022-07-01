using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ServiceDetailProviderFindServiceDetailRequest : JdRequestBase<ServiceDetailProviderFindServiceDetailResponse>
    {
                                                                                  public  		Nullable<int>
              afsServiceId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  appendInfoStep {get; set; }
                                                                                                                                                                                                                                                            public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorNick
 {get; set;}
                                                          
                                                          public  		string
              operatorRemark
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorDate
 {get; set;}
                                                          
                                                          public  		string
              platformSrc
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ServiceDetailProvider.findServiceDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("afsServiceId", this.            afsServiceId
);
                                                                                                                                                parameters.Add("appendInfoStep", this.            appendInfoStep
);
                                                                                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorNick", this.            operatorNick
);
                                                                                                        parameters.Add("operatorRemark", this.            operatorRemark
);
                                                                                                        parameters.Add("operatorDate", this.            operatorDate
);
                                                                                                        parameters.Add("platformSrc", this.            platformSrc
);
                                                                            }
    }
}





        
 

