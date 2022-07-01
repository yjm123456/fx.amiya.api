using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PresortSitefenceimportServiceRequest : JdRequestBase<PresortSitefenceimportServiceResponse>
    {
                                                                                                                                                                               public  		string
              operationType
 {get; set;}
                                                          
                                                          public  		string
              siteCode
 {get; set;}
                                                          
                                                          public  		string
              siteName
 {get; set;}
                                                          
                                                          public  		string
              siteLocation
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              fenceNum
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  fenceArray {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.presort.sitefenceimport.service";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("operationType", this.            operationType
);
                                                                                                        parameters.Add("siteCode", this.            siteCode
);
                                                                                                        parameters.Add("siteName", this.            siteName
);
                                                                                                        parameters.Add("siteLocation", this.            siteLocation
);
                                                                                                        parameters.Add("fenceNum", this.            fenceNum
);
                                                                                                                                                parameters.Add("fenceArray", this.            fenceArray
);
                                                                                                    }
    }
}





        
 

