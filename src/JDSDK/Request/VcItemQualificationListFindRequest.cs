using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemQualificationListFindRequest : JdRequestBase<VcItemQualificationListFindResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      categoryId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      brandId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                                                      beginAuditTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      endAuditTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              state
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              offset
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vc.item.qualification.list.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("category_id", this.                                                                                    categoryId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("brand_id", this.                                                                                    brandId
);
                                                                                                        parameters.Add("begin_audit_time", this.                                                                                                                    beginAuditTime
);
                                                                                                        parameters.Add("end_audit_time", this.                                                                                                                    endAuditTime
);
                                                                                                        parameters.Add("state", this.            state
);
                                                                                                        parameters.Add("offset", this.            offset
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                            }
    }
}





        
 

