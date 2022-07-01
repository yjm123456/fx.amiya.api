using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemProductAppliesFindRequest : JdRequestBase<VcItemProductAppliesFindResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      wareName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
              state
 {get; set;}
                                                          
                                                          public  		string
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              length
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.vc.item.product.applies.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("ware_name", this.                                                                                    wareName
);
                                                                                                        parameters.Add("state", this.            state
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("length", this.            length
);
                                                                            }
    }
}





        
 

