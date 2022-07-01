using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CreateBomOutRequest : JdRequestBase<CreateBomOutResponse>
    {
                                                                                                                                              public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  materialNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  materialCode {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.createBomOut";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                                                                                                        parameters.Add("materialNum", this.            materialNum
);
                                                                                                        parameters.Add("materialCode", this.            materialCode
);
                                                                                                                            }
    }
}





        
 

