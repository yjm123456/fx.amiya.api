using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoUpdateB2BSWbMainExpressItemQtyRequest : JdRequestBase<EclpCoUpdateB2BSWbMainExpressItemQtyResponse>
    {
                                                                                  public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              newWBType
 {get; set;}
                                                          
                                                          public  		string
              no
 {get; set;}
                                                          
                                                          public  		string
              expressItemQty
 {get; set;}
                                                          
                                                                                           public  		string
              extendFieldStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eclp.co.updateB2BSWbMainExpressItemQty";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("newWBType", this.            newWBType
);
                                                                                                        parameters.Add("no", this.            no
);
                                                                                                        parameters.Add("expressItemQty", this.            expressItemQty
);
                                                                                                                                                        parameters.Add("extendFieldStr", this.            extendFieldStr
);
                                                    }
    }
}





        
 

