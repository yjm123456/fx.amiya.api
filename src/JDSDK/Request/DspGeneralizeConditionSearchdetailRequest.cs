using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspGeneralizeConditionSearchdetailRequest : JdRequestBase<DspGeneralizeConditionSearchdetailResponse>
    {
                                                                                  public  		string
              token
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              keyValue
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              equipment
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		string
              areaValue
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.generalize.condition.searchdetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("token", this.            token
);
                                                                                                                                                                                                                                                parameters.Add("keyValue", this.            keyValue
);
                                                                                                        parameters.Add("equipment", this.            equipment
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("areaValue", this.            areaValue
);
                                                                            }
    }
}





        
 

